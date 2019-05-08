﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIPv2.Application.Web.Components.Controllers;
using BIPv2.Application.Web.ViewModels;
using BIPv2.Business.Services.IServices;
using BIPv2.Data.Domain.CustomEntities;
using BIPv2.Data.Domain.CustomRequestEntities;
using BIPv2.Data.Domain.Entities;
using BIPv2.Data.Domain.Enums;
using BIPv2.Data.Domain.RequestEntities;
using BIPv2.Data.Domain.ResultEntities;
using Nuevo.Framework.Data.Domain.Business;
using Nuevo.Framework.Infrastructure.Core.Extensions;
using Nuevo.Framework.Infrastructure.Core.Helpers;
using BIPv2.Business.Services.Services;


namespace BIPv2.Application.Web.Controllers
{
    public class MessageController : SecureBaseController
    {
        #region " IoC "

        private readonly IInternalMessageBusinessLogic _internalMessageBusinessLogic;
        private readonly IInternalMessageSendableListBusinessLogic _internalMessageSendableListBusinessLogic;
        private readonly IUserStuffBusinessLogic _userStuffBusinessLogic;
        private readonly IInternalMessageAttachmentBusinessLogic _attachmentBusinessLogic;
        private readonly IInternalMessageToBusinessLogic _internalMessageToBusinessLogic;
        private readonly IDealerGroupBusinessLogic _dealerGroupBusinessLogic;
        private readonly IUserBusinessLogic _userBusinessLogic;

        public MessageController(IInternalMessageBusinessLogic internalMessageBusinessLogic, IInternalMessageSendableListBusinessLogic internalMessageSendableListBusinessLogic, IUserStuffBusinessLogic userStuffBusinessLogic,
            IInternalMessageAttachmentBusinessLogic attachmentBusinessLogic, IInternalMessageToBusinessLogic internalMessageToBusinessLogic, IDealerGroupBusinessLogic dealerGroupBusinessLogic, IUserBusinessLogic userBusinessLogic)
        {
            _internalMessageBusinessLogic = internalMessageBusinessLogic;
            _internalMessageSendableListBusinessLogic = internalMessageSendableListBusinessLogic;
            _userStuffBusinessLogic = userStuffBusinessLogic;
            _attachmentBusinessLogic = attachmentBusinessLogic;
            _internalMessageToBusinessLogic = internalMessageToBusinessLogic;
            _dealerGroupBusinessLogic = dealerGroupBusinessLogic;
            _userBusinessLogic = userBusinessLogic;
        }

        #endregion

        public ActionResult Index(MessageViewModel model)
        {
            if (!HasMessagingAccessCurrentUser(BrandManager.CurrentBrandEnum, CurrentUserData))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }

            return View(model);
        }

        public ActionResult External()
        {
            if (!HasMessagingAccessCurrentUser(BrandManager.CurrentBrandEnum, CurrentUserData))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }

            return View();
        }

        public static bool HasMessagingAccessCurrentUser(BrandEnum currentBrand, UserData userData)
        {
            return currentBrand != BrandEnum.BipService && (
                userData.Type == UserType.Admin ||
                userData.Type == UserType.BSHSpecific ||
                userData.Type == UserType.BSHGeneric ||
                userData.Type == UserType.ThirdParty ||
                (userData.Type == UserType.Dealer && userData.UserPermission.HasMessagingAccess) ||
                (userData.Type == UserType.ServiceUser && userData.UserPermission.HasMessagingAccess));
        }

        [HttpGet]
        public ActionResult ExternalLoginGetHash()
        {
            if (CurrentUserData.UserDealerDetail != null)
            {
                return Json(_internalMessageBusinessLogic.ExternalLoginGetHash(BipConfiguration.ExternalMessage.Url, CurrentUserData.User.Email, CurrentUserData.UserDealerDetail.EmailPassword).ResultValue, JsonRequestBehavior.AllowGet);
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddUserToReceiversFromFile(HttpPostedFileBase postedFile, bool? includeSubUsers)
        {
            if (postedFile == null)
            {
                return JsonIframe(false);
            }

            var response = _internalMessageBusinessLogic.ListUsersFromFile(BrandManager.CurrentBrand.Id, postedFile.InputStream, includeSubUsers ?? false);
            return JsonIframe(response);
        }

        #region " Box "

        [HttpPost]
        public ActionResult Inbox(InternalMessageListInboxRequest internalMessageListInboxRequest)
        {
            //02.12.2016 - Ümit
            //Anasayfa mesajlardan gelen istekte deðerler bazý durumlarda null oluyor. 
            //Hata oluþmamasý için eklenmiþtir.
            if (!internalMessageListInboxRequest.PageNumber.HasValue)
                internalMessageListInboxRequest.PageNumber = 1;
            if (!internalMessageListInboxRequest.PageSize.HasValue)
                internalMessageListInboxRequest.PageSize = 7;
            int total;
            internalMessageListInboxRequest.UserId = CurrentUserData.User.Id;
            var response = _internalMessageBusinessLogic.ListInbox(internalMessageListInboxRequest, out total);
            if (CurrentUserData.Type != UserType.Admin && CurrentUserData.Type != UserType.BSHSpecific && CurrentUserData.Type != UserType.BSHGeneric && response.Success)
            {
                response.ResultValue.ForEach(x => x.TotalSent = 1);
            }
            return Json(new { response, total });
        }

        [HttpPost]
        public ActionResult Sentbox(int pageNumber, byte pageSize)
        {
            int total;
            var response = _internalMessageBusinessLogic.ListSentBox(CurrentUserData.User.Id, pageNumber, pageSize, out total);
            return Json(new { response, total });
        }

        [HttpPost]
        public ActionResult Draftbox(int pageNumber, byte pageSize)
        {
            int total;
            var response = _internalMessageBusinessLogic.ListDraftBox(CurrentUserData.User.Id, pageNumber, pageSize, out total);
            return Json(new { response, total });
        }

        [HttpPost]
        public ActionResult Trashbox(int pageNumber, byte pageSize)
        {
            int total;
            var response = _internalMessageBusinessLogic.ListTrashBox(CurrentUserData.User.Id, pageNumber, pageSize, out total);
            return Json(new { response, total });
        }

        [HttpPost]
        public ActionResult MessageUsers(int messageId, int exceptId, bool isBcc)
        {
            if (CurrentUserData.Type == UserType.Admin || CurrentUserData.Type == UserType.BSHSpecific || CurrentUserData.Type == UserType.BSHGeneric)
            {
                return Json(_internalMessageToBusinessLogic.ListUserDetail(messageId, exceptId, isBcc).ResultValue);

            }

            return Json(new List<InternalMessageListMessageUsersResult>
            {
                new InternalMessageListMessageUsersResult
                {
                    UserId = CurrentUserData.User.Id,
                    Firstname = CurrentUserData.User.Firstname,
                    Lastname = CurrentUserData.User.Lastname
                }
            });
        }

        [HttpPost]
        public ActionResult Detail(int messageId, bool isReceivingMessage)
        {
            var response = _internalMessageBusinessLogic.MessageDetail(CurrentUserData.User.Id, messageId, isReceivingMessage).ResultValue;

            bool canSeeFromRole = true;
            List<InternalMessageAttachmentEntity> internalMessageAttachments = null;
            if (response.Attachments)
            {
                internalMessageAttachments = _attachmentBusinessLogic.ListByMessageId(response.Id).ResultValue;
            }
            List<InternalMessageListMessageUsersResult> toUsers = null;
            if (response.IsDraft)
            {
                toUsers = _internalMessageBusinessLogic.ListMessageUsers(messageId, CurrentUserData.User.Id).ResultValue;
            }
            if (CurrentUserData.Type != UserType.Admin && CurrentUserData.Type != UserType.BSHSpecific && CurrentUserData.Type != UserType.BSHGeneric && isReceivingMessage)
            {
                response.TotalSent = 1;
                canSeeFromRole = false;
            }

            var allToAndBccUser = _internalMessageToBusinessLogic.ListUserDetail(messageId, null, null).ResultValue;
            var mailSenderUser = _userBusinessLogic.GetById(_internalMessageBusinessLogic.GetById(messageId).ResultValue.CreatedBy.Value).ResultValue;
            var mailAllDetails = _internalMessageBusinessLogic.GetAllMessageDetail(allToAndBccUser, CurrentUserData.User.Id, messageId, canSeeFromRole, mailSenderUser).ResultValue;

            return Json(new { detail = response, attachments = internalMessageAttachments, toUsers, mailAllDetails });
        }

        [HttpPost]
        public ActionResult ForwardOrDraftUserDetails(int internalMessageId, MessageConditionStatus messageCondition)
        {
            bool IsSender = false;
            if (messageCondition == MessageConditionStatus.SendBox || messageCondition == MessageConditionStatus.DraftBox)
            {//Bahsi geçen mesaj için su an ki kullanici gönderici pozisyonunda, tümünü yanitla için bütün to ve bccler gelecek
                IsSender = true;
            }
            else
            {
                IsSender = false;
            }

            var response = _internalMessageBusinessLogic.MessageDetail(CurrentUserData.User.Id, internalMessageId, !IsSender).ResultValue;


            List<InternalMessageAttachmentEntity> internalMessageAttachments = null;
            if (response.Attachments)
            {
                internalMessageAttachments = _attachmentBusinessLogic.ListByMessageId(response.Id).ResultValue;
            }
            List<InternalMessageToListUserDetailResult> userDetails;
            if (IsSender)
            {
                userDetails = _internalMessageToBusinessLogic.ListUserDetail(internalMessageId, null, null).ResultValue;
            }
            else
            {
                userDetails = _internalMessageToBusinessLogic.ListUserDetail(internalMessageId, null, IsSender).ResultValue;
            }

            List<InternalMessageToListUserDetailResult> bccList = userDetails.Where(x => x.IsBCC == true).ToList();
            List<InternalMessageToListUserDetailResult> toList = userDetails.Where(x => x.IsBCC == false || x.IsBCC == null).ToList();

            if (!IsSender)
            {
                var mailSenderUser = _userBusinessLogic.GetById(_internalMessageBusinessLogic.GetById(internalMessageId).ResultValue.CreatedBy.Value).ResultValue;

                var mailSenderCast = new InternalMessageToListUserDetailResult()
                {
                    Firstname = mailSenderUser.Firstname,
                    Lastname = mailSenderUser.Lastname,
                    UserId = mailSenderUser.Id
                };
                toList.Add(mailSenderCast);
                if (toList.Any(x => x.UserId == CurrentUserData.User.Id))
                {
                    var currentTo = toList.FirstOrDefault(x => x.UserId == CurrentUserData.User.Id);
                    toList.Remove(currentTo);
                }
            }
            return Json(new { detail = response, attachments = internalMessageAttachments, bccList, toList });

        }
        [HttpPost]
        public ActionResult UnreadMessages()
        {
            var response = _internalMessageBusinessLogic.UnreadMessagesCount(CurrentUserData.User.Id);
            return Json(new { response, total = response.ResultValue });
        }

        #endregion

        #region " Actions "

        [HttpPost]
        public ActionResult AttachmentsSeen(List<int> toIds)
        {
            var response = _internalMessageBusinessLogic.SetAttachmentsSeenBulk(toIds, CurrentUserData.User.Id, true);
            return Json(new { response });
        }

        [HttpPost]
        public ActionResult DeleteInboxItems(List<int> toIds)
        {
            var response = _internalMessageBusinessLogic.SetInboxDeleteStatusBulk(toIds, CurrentUserData.User.Id, MessageStatus.Deleted);
            return Json(new { response });
        }

        [HttpPost]
        public ActionResult DeleteSentboxItems(List<int> ids)
        {
            var response = _internalMessageBusinessLogic.SetSentboxDeleteStatusBulk(ids, CurrentUserData.User.Id, MessageStatus.Deleted);
            return Json(new { response });
        }

        [HttpPost]
        public ActionResult DeleteTrashboxItems(List<int> ids, List<int> toIds)
        {
            ServiceResult<int> responseInbox = null;
            if (ids != null && ids.Count > 0)
            {
                responseInbox = _internalMessageBusinessLogic.SetSentboxDeleteStatusBulk(ids, CurrentUserData.User.Id, MessageStatus.TotallyDeleted);
            }

            ServiceResult<int> responseSentbox = null;
            if (toIds != null && toIds.Count > 0)
            {
                responseSentbox = _internalMessageBusinessLogic.SetInboxDeleteStatusBulk(toIds, CurrentUserData.User.Id, MessageStatus.TotallyDeleted);
            }
            return Json(new { responseInbox, responseSentbox });
        }

        [HttpPost]
        public ActionResult UndoTrashboxItems(List<int> ids, List<int> toIds)
        {
            ServiceResult<int> responseInbox = null;
            if (ids != null && ids.Count > 0)
            {
                responseInbox = _internalMessageBusinessLogic.SetSentboxDeleteStatusBulk(ids, CurrentUserData.User.Id, 0);
            }

            ServiceResult<int> responseSentbox = null;
            if (toIds != null && toIds.Count > 0)
            {
                responseSentbox = _internalMessageBusinessLogic.SetInboxDeleteStatusBulk(toIds, CurrentUserData.User.Id, 0);
            }
            return Json(new { responseInbox, responseSentbox });
        }

        [HttpPost]
        public ActionResult DeleteDraftItems(List<int> ids)
        {
            var response = _internalMessageBusinessLogic.SetSentboxDeleteStatusBulk(ids, CurrentUserData.User.Id, MessageStatus.TotallyDeleted);
            return Json(new { response });
        }

        [HttpPost]
        public ActionResult Seen(List<int> toIds)
        {
            var response = _internalMessageBusinessLogic.SetSeenBulk(toIds, CurrentUserData.User.Id, true);
            return Json(new { response });
        }

        [HttpPost]
        public ActionResult UnSeen(List<int> toIds)
        {
            var response = _internalMessageBusinessLogic.SetSeenBulk(toIds, CurrentUserData.User.Id, false);
            return Json(new { response });
        }

        [HttpPost]
        public ActionResult DeleteDraftAttachment(int messageId, int attachmentId)
        {
            var folderPath = Server.MapPath("/Upload/Message");

            //return Json(_internalMessageBusinessLogic.DeleteDraftAttachment(messageId, CurrentUserData.User.Id, attachmentId));
            return Json(_internalMessageBusinessLogic.DeleteDraftAttachmentAndFile(messageId, CurrentUserData.User.Id, attachmentId, folderPath));
        }

        [HttpPost]
        public ActionResult UndoSentboxItems(List<int> ids)
        {
            var response = _internalMessageBusinessLogic.UndoSentboxItems(ids, CurrentUserData.User.Id);
            return Json(response);
        }

        #endregion

        #region " Send Message "

        [HttpGet]
        public ActionResult SearchIndexBindDropDowns()
        {
            int? userStuffId = null;
            switch (CurrentUserData.Type)
            {
                case UserType.BSHSpecific:
                case UserType.BSHGeneric:
                    userStuffId = CurrentUserData.User.UserStuffId;
                    break;
                case UserType.Dealer:
                    var userStuffRank = CurrentUserData.UserDealerDetail.IsMainUser ? UserStuffRank.DealerMainUser : UserStuffRank.DealerSubUser;
                    userStuffId = _userStuffBusinessLogic.GetByRank(BrandManager.CurrentBrand.Id, userStuffRank).ResultValue.Id;
                    break;
                case UserType.ThirdParty:
                    userStuffId = _userStuffBusinessLogic.GetByRank(BrandManager.CurrentBrand.Id, UserStuffRank.Vendor).ResultValue.Id;
                    break;
            }
            var userStuffs = _internalMessageSendableListBusinessLogic.ListUserStuffs(BrandManager.CurrentBrand.Id, userStuffId).ResultValue;
            return Json(new { userStuffs }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SearchIndexBindDealerGroups()
        {
            var dealerGroups = _dealerGroupBusinessLogic.ListByBrandIdAndStatus(BrandManager.CurrentBrand.Id, GenericEntityStatus.Active).ResultValue;
            return Json(new { dealerGroups }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SearchUsersForSendingMessage(InternalMessageListSearchUsersForSendingMessageV2Request requestModel)
        {
            requestModel.UserId = CurrentUserData.User.Id;
            requestModel.BrandId = BrandManager.CurrentBrand.Id;
            requestModel.DealerCode = CurrentUserData.User.Type == UserType.Dealer ? CurrentUserData.UserDealerDetail.DealerCode : null;
            requestModel.UserStuffId = CurrentUserData.User.UserStuffId;
            requestModel.UserType = CurrentUserData.User.Type.ToByte();
            requestModel.Name = string.IsNullOrEmpty(requestModel.Name) ? null : requestModel.Name.Trim();
            var response = _internalMessageBusinessLogic.ListSearchUsersForSendingMessageV2(requestModel);
            return Json(new { response });
        }

        [HttpPost]
        public ActionResult SearchUsersForSendingMessageByDealerGroup(string dealerGroupIds, bool includeSubUsers)
        {
            var response = _userBusinessLogic.ListBulkSelectByDealerGroupId(BrandManager.CurrentBrand.Id, dealerGroupIds, includeSubUsers);
            return Json(new { response });
        }

        [HttpPost]
        public ActionResult SendMessage(MessageSendMessageViewModel messageViewModel)
        {

            if (messageViewModel == null)
                return null;
            var response = _internalMessageBusinessLogic.SendOrSaveMessage(messageViewModel.DraftId, messageViewModel.Action == "draft", CurrentUserData.User.Id, messageViewModel.Ids, messageViewModel.Subject, messageViewModel.Body, messageViewModel.Attachments, messageViewModel.AttachmentIds, messageViewModel.BCCIds);
            return JsonIframe(new { response });
        }

        #endregion

        #region " Sendable List "

        public ActionResult SendableListIndex()
        {
            var allList = _internalMessageSendableListBusinessLogic.ListAll(BrandManager.CurrentBrand.Id).ResultValue;
            var userStuffs = _userStuffBusinessLogic.ListByBrandId(BrandManager.CurrentBrand.Id).ResultValue;

            return View("SendableListIndex", new InternalMessageSendableListViewModel
            {
                SendableList = allList,
                UserStuffs = userStuffs
            });
        }

        [HttpPost]
        public ActionResult SendableListUpdate()
        {
            var internalMessageSendableLists = new List<InternalMessageSendableListEntity>();

            #region " Form Data To List "

            foreach (var key in Request.Form.Keys)
            {
                if (!key.ToString().StartsWith("sendable_"))
                    continue;

                // sendable_{FromUserStuffId}_{ToUserStuffId}
                var splitedData = key.ToString().Split('_');

                internalMessageSendableLists.Add(new InternalMessageSendableListEntity
                {
                    BrandId = BrandManager.CurrentBrand.Id,
                    FromUserStuffId = Convert.ToInt32(splitedData[1]),
                    ToUserStuffId = Convert.ToInt32(splitedData[2]),
                });
            }

            #endregion

            var response = _internalMessageSendableListBusinessLogic.BulkUpdate(BrandManager.CurrentBrand.Id, internalMessageSendableLists);
            return Json(response);
        }

        #endregion


        [HttpPost]
        public ActionResult GoTraining(int currentMessageId)
        {
            UserEntity currentUser = CurrentUserData.User;
            //if (currentUser.IdGuid == Guid.Empty || currentUser.IdGuid == null)
            //{
            //    currentUser.IdGuid = Guid.NewGuid();
            //    _userBusinessLogic.UpdateById(currentUser);
            //    //1 IsGuid Yok Setting Ile otomatık olustur?

            //}

            NetTrainmentApiHelper netTrainmentApiHelper = new NetTrainmentApiHelper(BrandManager.CurrentBrandEnum);

            NetTrainmentUserModel responseGet = netTrainmentApiHelper.GetModelByGuid(currentUser.IdGuid.ToString()).Result;

            //responseGet.StatusCode = StatusCode.YapilanIslemOlumsuz;

            if (responseGet.StatusCode == StatusCode.YapilanIslemOlumsuz)
            {
                NetTrainmentUserModel responsePost = netTrainmentApiHelper.Post(netTrainmentApiHelper.CastModel(currentUser));
                if (responsePost.StatusCode == StatusCode.YapilanIslemOlumsuz)
                {
                    //SORUN VAR
                    return View();
                }

                //YONLENDIRME ISELMLERI
                var aa = responsePost.Identifier;
                return View();
                //EKLEMIS OLDUK
            }
            //YONLENDIRME ISELMLERI
            var asfas = responseGet.Identifier;
            //EKLEMIS OLDUK
            return View();

            //return !string.IsNullOrWhiteSpace(redirectLink) ? (ActionResult)Redirect(redirectLink) : RedirectToAction("Index");


        }


    }
}