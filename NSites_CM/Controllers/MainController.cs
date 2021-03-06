﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

using NSites_CM.Models.Generics;
using NSites_CM.Models.Lendings;
using NSites_CM.Models.HRISs;
//using NSites_CM.Models.Payrolls;
using NSites_CM.Models.Systems;

using System.Data;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace NSites_CM.Controllers
{
    public class MainController : ApiController
    {
        #region "INITIALIZATION"
        //Generics
        Common loCommon = new Common();
       
        //Lendings
        Client loClient = new Client();
        ClientFamilyMember loClientFamilyMember = new ClientFamilyMember();
        ClientPersonalReference loClientPersonalReference = new ClientPersonalReference();
        ClientSourceOfIncome loClientSourceOfIncome = new ClientSourceOfIncome();
        ClientOwnedProperty loClientOwnedProperty = new ClientOwnedProperty();
        ClientCreditExperience loClientCreditExperience = new ClientCreditExperience();
        Area loArea = new Area();
        Branch loBranch = new Branch();
        Zone loZone = new Zone();
        Collector loCollector = new Collector();
        Product loProduct = new Product();
        LoanApplication loLoanApplication = new LoanApplication();
        LoanApplicationDetail loLoanApplicationDetail = new LoanApplicationDetail();
        LoanEndOfDay loLoanEndOfDay = new LoanEndOfDay();
        LoanEndOfDayDetail loLoanEndOfDayDetail = new LoanEndOfDayDetail();
        //HRISs
        Employee loEmployee = new Employee();
        EmploymentType loEmploymentType = new EmploymentType();
        Designation loDesignation = new Designation();
        Department loDepartment = new Department();
        LeaveType loLeaveType = new LeaveType();
        Holiday loHoliday = new Holiday();
        EarningType loEarningType = new EarningType();
        DeductionType loDeductionType = new DeductionType();
        TaxType loTaxType = new TaxType();
        IncomeTaxTable loIncomeTaxTable = new IncomeTaxTable();
        WorkSchedule loWorkSchedule = new WorkSchedule();
        DailyTimeRecord loDailyTimeRecord = new DailyTimeRecord();
        COAEntry loCOAEntry = new COAEntry();
        LeaveEntry loLeaveEntry = new LeaveEntry();
        OvertimeEntry loOvertimeEntry = new OvertimeEntry();
        HolidayEntry loHolidayEntry = new HolidayEntry();
        //Payrolls

        //Systems
        User loUser = new User();
        UserGroup loUserGroup = new UserGroup();
        SystemConfiguration loSystemConfigurations = new SystemConfiguration();
        AuditTrail loAuditTrail = new AuditTrail();
        #endregion

        #region "GENERICS"
        [HttpGet]
        public string test()
        {
            return "Test Successful!";
        }

        [HttpGet]
        public DataTable getDataFromSearch(string pQueryString)
        {
            return loCommon.getDataFromSearch(pQueryString);
        }

        [HttpGet]
        public DataTable getUserGroupMenuItems(string pUsername)
        {
            return loCommon.getUserGroupMenuItems(pUsername);
        }

        [HttpGet]
        public DataTable getUserGroupRights(string pUsername)
        {
            return loCommon.getUserGroupRights(pUsername);
        }

        [HttpGet]
        public DataTable getMenuItems()
        {
            return loCommon.getMenuItems();
        }

        [HttpGet]
        public DataTable getAllMenuItems()
        {
            return loCommon.getAllMenuItems();
        }

        [HttpGet]
        public DataTable getAllRights(string pItemName)
        {
            return loCommon.getAllRights(pItemName);
        }

        [HttpGet]
        public DataTable getMenuItemsByGroup(string pUserGroupId)
        {
            return loCommon.getMenuItemsByGroup(pUserGroupId);
        }

        [HttpGet]
        public DataTable getEnableRights(string pItemName, string pUserGroupId)
        {
            return loCommon.getEnableRights(pItemName, pUserGroupId);
        }

        [HttpGet]
        public DataTable getEnableCompanys(string pUserGroupId)
        {
            return loCommon.getEnableCompanys(pUserGroupId);
        }

        [HttpGet]
        public bool sendEmail(string pFrom, string pTo, string pCC, string pSubject, string pBody, string pUsername, string pUserPassword)
        {
            return loCommon.sendEmail(pFrom, pTo, pCC, pSubject, pBody, pUsername, pUserPassword);
        }

        [HttpGet]
        public DataTable getTemplateNames(string pMenuName, string pUserId)
        {
            return loCommon.getTemplateNames(pMenuName, pUserId);
        }

        [HttpGet]
        public DataTable getTemplateName(string pId)
        {
            return loCommon.getTemplateName(pId);
        }

        [HttpGet]
        public DataTable getSearchFilters(string pTemplateId)
        {
            return loCommon.getSearchFilters(pTemplateId);
        }

        [HttpGet]
        public string insertSearchTemplate(string pTemplateName, string pItemName, string pPrivate, string pUserId)
        {
            return loCommon.insertSearchTemplate(pTemplateName, pItemName, pPrivate, pUserId);
        }

        [HttpGet]
        public bool removeSearchFilter(string pTemplateId)
        {
            return loCommon.removeSearchFilter(pTemplateId);
        }

        [HttpGet]
        public bool removeSearchTemplate(string pId)
        {
            return loCommon.removeSearchTemplate(pId);
        }

        [HttpGet]
        public bool renameSearchTemplate(string pId, string pTemplateName)
        {
            return loCommon.renameSearchTemplate(pId, pTemplateName);
        }

        [HttpGet]
        public bool updateSearchTemplate(string pId, string pTemplateName, string pItemName, string pPrivate)
        {
            return loCommon.updateSearchTemplate(pId, pTemplateName, pItemName, pPrivate);
        }

        [HttpGet]
        public bool insertSearchFilter(string pTemplateId, string pField, string pOperator, string pValue, string pCheckAnd, string pCheckOr, int pSequence)
        {
            return loCommon.insertSearchFilter(pTemplateId, pField, pOperator, pValue, pCheckAnd, pCheckOr,pSequence);
        }

        [HttpGet]
        public DataTable getViewDetails()
        {
            return loCommon.getViewDetails();
        }

        [HttpGet]
        public DataTable getStoredProcedureDetails(string pDatabaseName)
        {
            return loCommon.getStoredProcedureDetails(pDatabaseName);
        }

        [HttpGet]
        public DataTable getFunctionDetails(string pDatabaseName)
        {
            return loCommon.getFunctionDetails(pDatabaseName);
        }

        [HttpGet]
        public DataTable getTableDetails()
        {
            return loCommon.getTableDetails();
        }

        [HttpGet]
        public DataTable getMenuItemDetails()
        {
            return loCommon.getMenuItemDetails();
        }

        [HttpGet]
        public DataTable getItemRightDetails()
        {
            return loCommon.getItemRightDetails();
        }

        [HttpGet]
        public DataTable getSystemConfigurationDetails()
        {
            return loCommon.getSystemConfigurationDetails();
        }

        [HttpGet]
        public DataTable getNextTabelSequenceId(string pDescription)
        {
            return loCommon.getNextTabelSequenceId(pDescription);
        }
        #endregion "END OF GLOBAL"

        #region "LENDINGS"
        #region "Client"
        [HttpGet]
        public DataTable getClients(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loClient.getClients(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getClientLists()
        {
            return loClient.getClientLists();
        }

        [HttpPost]
        public string insertClient([FromBody]Client pClient)
        {
            return loClient.insertClient(pClient);
        }

        [HttpPost]
        public string updateClient([FromBody]Client pClient)
        {
            return loClient.updateClient(pClient);
        }

        [HttpGet]
        public bool removeClient(string pId, string pUserId)
        {
            return loClient.removeClient(pId, pUserId);
        }
        #endregion

        #region "Client Family Member"
        [HttpGet]
        public DataTable getClientFamilyMembers(string pClientId, string pPrimaryKey)
        {
            return loClientFamilyMember.getClientFamilyMembers(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientFamilyMember([FromBody]ClientFamilyMember pClientFamilyMember)
        {
            return loClientFamilyMember.insertClientFamilyMember(pClientFamilyMember);
        }

        [HttpPost]
        public string updateClientFamilyMember([FromBody]ClientFamilyMember pClientFamilyMember)
        {
            return loClientFamilyMember.updateClientFamilyMember(pClientFamilyMember);
        }

        [HttpGet]
        public bool removeClientFamilyMember(string pId, string pUserId)
        {
            return loClientFamilyMember.removeClientFamilyMember(pId, pUserId);
        }
        #endregion

        #region "Client Personal Reference"
        [HttpGet]
        public DataTable getClientPersonalReferences(string pClientId, string pPrimaryKey)
        {
            return loClientPersonalReference.getClientPersonalReferences(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientPersonalReference([FromBody]ClientPersonalReference pClientPersonalReference)
        {
            return loClientPersonalReference.insertClientPersonalReference(pClientPersonalReference);
        }

        [HttpPost]
        public string updateClientPersonalReference([FromBody]ClientPersonalReference pClientPersonalReference)
        {
            return loClientPersonalReference.updateClientPersonalReference(pClientPersonalReference);
        }

        [HttpGet]
        public bool removeClientPersonalReference(string pId, string pUserId)
        {
            return loClientPersonalReference.removeClientPersonalReference(pId, pUserId);
        }
        #endregion

        #region "Client Source Of Income"
        [HttpGet]
        public DataTable getClientSourceOfIncomes(string pClientId, string pPrimaryKey)
        {
            return loClientSourceOfIncome.getClientSourceOfIncomes(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientSourceOfIncome([FromBody]ClientSourceOfIncome pClientSourceOfIncome)
        {
            return loClientSourceOfIncome.insertClientSourceOfIncome(pClientSourceOfIncome);
        }

        [HttpPost]
        public string updateClientSourceOfIncome([FromBody]ClientSourceOfIncome pClientSourceOfIncome)
        {
            return loClientSourceOfIncome.updateClientSourceOfIncome(pClientSourceOfIncome);
        }

        [HttpGet]
        public bool removeClientSourceOfIncome(string pId, string pUserId)
        {
            return loClientSourceOfIncome.removeClientSourceOfIncome(pId, pUserId);
        }
        #endregion

        #region "Client Owned Property"
        [HttpGet]
        public DataTable getClientOwnedPropertys(string pClientId, string pPrimaryKey)
        {
            return loClientOwnedProperty.getClientOwnedPropertys(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientOwnedProperty([FromBody]ClientOwnedProperty pClientOwnedProperty)
        {
            return loClientOwnedProperty.insertClientOwnedProperty(pClientOwnedProperty);
        }

        [HttpPost]
        public string updateClientOwnedProperty([FromBody]ClientOwnedProperty pClientOwnedProperty)
        {
            return loClientOwnedProperty.updateClientOwnedProperty(pClientOwnedProperty);
        }

        [HttpGet]
        public bool removeClientOwnedProperty(string pId, string pUserId)
        {
            return loClientOwnedProperty.removeClientOwnedProperty(pId, pUserId);
        }
        #endregion

        #region "Client Credit Experience"
        [HttpGet]
        public DataTable getClientCreditExperiences(string pClientId, string pPrimaryKey)
        {
            return loClientCreditExperience.getClientCreditExperiences(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientCreditExperience([FromBody]ClientCreditExperience pClientCreditExperience)
        {
            return loClientCreditExperience.insertClientCreditExperience(pClientCreditExperience);
        }

        [HttpPost]
        public string updateClientCreditExperience([FromBody]ClientCreditExperience pClientCreditExperience)
        {
            return loClientCreditExperience.updateClientCreditExperience(pClientCreditExperience);
        }

        [HttpGet]
        public bool removeClientCreditExperience(string pId, string pUserId)
        {
            return loClientCreditExperience.removeClientCreditExperience(pId, pUserId);
        }
        #endregion

        #region "Area"
        [HttpGet]
        public DataTable getAreas(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loArea.getAreas(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertArea([FromBody]Area pArea)
        {
            return loArea.insertArea(pArea);
        }

        [HttpPost]
        public string updateArea([FromBody]Area pArea)
        {
            return loArea.updateArea(pArea);
        }

        [HttpGet]
        public bool removeArea(string pId, string pUserId)
        {
            return loArea.removeArea(pId, pUserId);
        }
        #endregion ""

        #region "Branch"
        [HttpGet]
        public DataTable getBranchs(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loBranch.getBranchs(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertBranch([FromBody]Branch pBranch)
        {
            return loBranch.insertBranch(pBranch);
        }

        [HttpPost]
        public string updateBranch([FromBody]Branch pBranch)
        {
            return loBranch.updateBranch(pBranch);
        }

        [HttpGet]
        public bool removeBranch(string pId, string pUserId)
        {
            return loBranch.removeBranch(pId, pUserId);
        }
        #endregion ""

        #region "Zone"
        [HttpGet]
        public DataTable getZones(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loZone.getZones(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertZone([FromBody]Zone pZone)
        {
            return loZone.insertZone(pZone);
        }

        [HttpPost]
        public string updateZone([FromBody]Zone pZone)
        {
            return loZone.updateZone(pZone);
        }

        [HttpGet]
        public bool removeZone(string pId, string pUserId)
        {
            return loZone.removeZone(pId, pUserId);
        }
        #endregion ""

        #region "Collector"
        [HttpGet]
        public DataTable getCollectors(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loCollector.getCollectors(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertCollector([FromBody]Collector pCollector)
        {
            return loCollector.insertCollector(pCollector);
        }

        [HttpPost]
        public string updateCollector([FromBody]Collector pCollector)
        {
            return loCollector.updateCollector(pCollector);
        }

        [HttpGet]
        public bool removeCollector(string pId, string pUserId)
        {
            return loCollector.removeCollector(pId, pUserId);
        }
        #endregion ""

        #region "Product"
        [HttpGet]
        public DataTable getProducts(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loProduct.getProducts(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertProduct([FromBody]Product pProduct)
        {
            return loProduct.insertProduct(pProduct);
        }

        [HttpPost]
        public string updateProduct([FromBody]Product pProduct)
        {
            return loProduct.updateProduct(pProduct);
        }

        [HttpGet]
        public bool removeProduct(string pId, string pUserId)
        {
            return loProduct.removeProduct(pId, pUserId);
        }
        #endregion ""

        #region "Loan Application"
        [HttpGet]
        public DataTable getLoanApplications(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loLoanApplication.getLoanApplications(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getLoanApplicationStatus(string pLoanApplicationId)
        {
            return loLoanApplication.getLoanApplicationStatus(pLoanApplicationId);
        }

        [HttpGet]
        public DataTable getForReleaseSheet(DateTime pReleaseDate, string pCollectorId)
        {
            return loLoanApplication.getForReleaseSheet(pReleaseDate, pCollectorId);
        }

        [HttpPost]
        public string insertLoanApplication([FromBody]LoanApplication pLoanApplication)
        {
            return loLoanApplication.insertLoanApplication(pLoanApplication);
        }

        [HttpPost]
        public string updateLoanApplication([FromBody]LoanApplication pLoanApplication)
        {
            return loLoanApplication.updateLoanApplication(pLoanApplication);
        }

        [HttpGet]
        public bool removeLoanApplication(string pId, string pUserId)
        {
            return loLoanApplication.removeLoanApplication(pId, pUserId);
        }

        [HttpGet]
        public bool approveLoanApplication(string pId, string pUserId)
        {
            return loLoanApplication.approveLoanApplication(pId, pUserId);
        }

        [HttpGet]
        public bool cancelLoanApplication(string pId, string pReason, string pUserId)
        {
            return loLoanApplication.cancelLoanApplication(pId, pReason, pUserId);
        }

        [HttpGet]
        public bool postLoanApplication(string pId, string pUserId)
        {
            return loLoanApplication.postLoanApplication(pId, pUserId);
        }
        #endregion ""

        #region "Loan Application Detail"
        [HttpGet]
        public DataTable getLoanApplicationDetails(string pLoanApplicationId)
        {
            return loLoanApplicationDetail.getLoanApplicationDetails(pLoanApplicationId);
        }

        [HttpGet]
        public DataTable getLoanApplicationDetail(string pDetailId)
        {
            return loLoanApplicationDetail.getLoanApplicationDetail(pDetailId);
        }

        [HttpGet]
        public DataTable getDailyCollectionSheet(DateTime pCollectionDate, string pCollectorId)
        {
            return loLoanApplicationDetail.getDailyCollectionSheet(pCollectionDate, pCollectorId);
        }

        [HttpGet]
        public DataTable getUploadCollectionList(DateTime pCollectionDate, string pCollectorId)
        {
            return loLoanApplicationDetail.getUploadCollectionList(pCollectionDate, pCollectorId);
        }

        [HttpGet]
        public DataTable getEODLoanApplicationDetail(DateTime pDate, string pBranchId)
        {
            return loLoanApplicationDetail.getEODLoanApplicationDetail(pDate, pBranchId);
        }

        [HttpGet]
        public DataTable getEODLoanApplicationDetailList(DateTime pDate, string pBranchId)
        {
            return loLoanApplicationDetail.getEODLoanApplicationDetailList(pDate, pBranchId);
        }

        [HttpPost]
        public bool insertLoanApplicationDetail([FromBody]LoanApplicationDetail pLoanApplicationDetail)
        {
            return loLoanApplicationDetail.insertLoanApplicationDetail(pLoanApplicationDetail);
        }

        [HttpPost]
        public bool updateLoanApplicationDetail([FromBody]LoanApplicationDetail pLoanApplicationDetail)
        {
            return loLoanApplicationDetail.updateLoanApplicationDetail(pLoanApplicationDetail);
        }

        [HttpGet]
        public bool removeLoanApplicationDetail(string pDetailId, string pUserId)
        {
            return loLoanApplicationDetail.removeLoanApplicationDetail(pDetailId, pUserId);
        }

        [HttpGet]
        public bool updatePayment(string pDetailId, decimal pPayment, decimal pNewBalance, decimal pVariance,
            string pPastDueReason, string pRemarks,string pCollectorId, string pUserId)
        {
            return loLoanApplicationDetail.updatePayment(pDetailId, pPayment, pNewBalance, pVariance, pPastDueReason, pRemarks,pCollectorId, pUserId);
        }

        [HttpGet]
        public bool updateEODLoanTransactionDetail(string pDetailId, string pEODId, string pUserId)
        {
            return loLoanApplicationDetail.updateEODLoanTransactionDetail(pDetailId, pEODId, pUserId);
        }
        #endregion ""

        #region "Loan End of Day"
        [HttpGet]
        public DataTable getLoanEndOfDays(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loLoanEndOfDay.getLoanEndOfDays(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getLoanEndOfDayByBranch(string pBranchId)
        {
            return loLoanEndOfDay.getLoanEndOfDayByBranch(pBranchId);
        }
        
        [HttpPost]
        public string insertLoanEndOfDay([FromBody]LoanEndOfDay pLoanEndOfDay)
        {
            return loLoanEndOfDay.insertLoanEndOfDay(pLoanEndOfDay);
        }

        [HttpPost]
        public string updateLoanEndOfDay([FromBody]LoanEndOfDay pLoanEndOfDay)
        {
            return loLoanEndOfDay.updateLoanEndOfDay(pLoanEndOfDay);
        }

        [HttpGet]
        public bool removeLoanEndOfDay(string pId, string pUserId)
        {
            return loLoanEndOfDay.removeLoanEndOfDay(pId, pUserId);
        }
        #endregion ""

        #region "Loan End of Day Detail"
        [HttpGet]
        public DataTable getLoanEndOfDayDetails(string pLoanEndOfDayId)
        {
            return loLoanEndOfDayDetail.getLoanEndOfDayDetails(pLoanEndOfDayId);
        }

        [HttpPost]
        public bool insertLoanEndOfDayDetail([FromBody]LoanEndOfDayDetail pLoanEndOfDayDetail)
        {
            return loLoanEndOfDayDetail.insertLoanEndOfDayDetail(pLoanEndOfDayDetail);
        }

        [HttpPost]
        public bool updateLoanEndOfDayDetail([FromBody]LoanEndOfDayDetail pLoanEndOfDayDetail)
        {
            return loLoanEndOfDayDetail.updateLoanEndOfDayDetail(pLoanEndOfDayDetail);
        }

        [HttpGet]
        public bool removeLoanEndOfDayDetail(string pDetailId, string pUserId)
        {
            return loLoanEndOfDayDetail.removeLoanEndOfDayDetail(pDetailId, pUserId);
        }
        #endregion ""

        #endregion

        #region "HRISS"

        #region "Employee"
        [HttpGet]
        public DataTable getEmployees(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loEmployee.getEmployees(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getAllActiveEmployees()
        {
            return loEmployee.getAllActiveEmployees();
        }

        [HttpGet]
        public DataTable getEmployeeNames()
        {
            return loEmployee.getEmployeeNames();
        }

        [HttpGet]
        public DataTable getEmployeeListByType(string pEmploymentTypeId, string pSearchString, string pDepartmentId)
        {
            return loDailyTimeRecord.getEmployeeListByType(pEmploymentTypeId, pSearchString, pDepartmentId);
        }

        [HttpPost]
        public string insertEmployee([FromBody]Employee pEmployee)
        {
            return loEmployee.insertEmployee(pEmployee);
        }

        [HttpPost]
        public string updateEmployee([FromBody]Employee pEmployee)
        {
            return loEmployee.updateEmployee(pEmployee);
        }

        [HttpGet]
        public bool removeEmployee(string pId, string pUserId)
        {
            return loEmployee.removeEmployee(pId, pUserId);
        }
        #endregion ""

        #region "Employment Type"
        [HttpGet]
        public DataTable getEmploymentTypes(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loEmploymentType.getEmploymentTypes(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertEmploymentType([FromBody]EmploymentType pEmploymentType)
        {
            return loEmploymentType.insertEmploymentType(pEmploymentType);
        }

        [HttpPost]
        public string updateEmploymentType([FromBody]EmploymentType pEmploymentType)
        {
            return loEmploymentType.updateEmploymentType(pEmploymentType);
        }

        [HttpGet]
        public bool removeEmploymentType(string pId, string pUserId)
        {
            return loEmploymentType.removeEmploymentType(pId, pUserId);
        }
        #endregion ""

        #region "Designation"
        [HttpGet]
        public DataTable getDesignations(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loDesignation.getDesignations(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertDesignation([FromBody]Designation pDesignation)
        {
            return loDesignation.insertDesignation(pDesignation);
        }

        [HttpPost]
        public string updateDesignation([FromBody]Designation pDesignation)
        {
            return loDesignation.updateDesignation(pDesignation);
        }

        [HttpGet]
        public bool removeDesignation(string pId, string pUserId)
        {
            return loDesignation.removeDesignation(pId, pUserId);
        }
        #endregion ""

        #region "Department"
        [HttpGet]
        public DataTable getDepartments(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loDepartment.getDepartments(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertDepartment([FromBody]Department pDepartment)
        {
            return loDepartment.insertDepartment(pDepartment);
        }

        [HttpPost]
        public string updateDepartment([FromBody]Department pDepartment)
        {
            return loDepartment.updateDepartment(pDepartment);
        }

        [HttpGet]
        public bool removeDepartment(string pId, string pUserId)
        {
            return loDepartment.removeDepartment(pId, pUserId);
        }
        #endregion ""

        #region "Leave Type"
        [HttpGet]
        public DataTable getLeaveTypes(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loLeaveType.getLeaveTypes(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertLeaveType([FromBody]LeaveType pLeaveType)
        {
            return loLeaveType.insertLeaveType(pLeaveType);
        }

        [HttpPost]
        public string updateLeaveType([FromBody]LeaveType pLeaveType)
        {
            return loLeaveType.updateLeaveType(pLeaveType);
        }

        [HttpGet]
        public bool removeLeaveType(string pId, string pUserId)
        {
            return loLeaveType.removeLeaveType(pId, pUserId);
        }
        #endregion ""

        #region "Holiday"
        [HttpGet]
        public DataTable getHolidays(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loHoliday.getHolidays(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getHolidayType(string pHolidayCode)
        {
            return loHoliday.getHolidayType(pHolidayCode);
        }

        [HttpPost]
        public string insertHoliday([FromBody]Holiday pHoliday)
        {
            return loHoliday.insertHoliday(pHoliday);
        }

        [HttpPost]
        public string updateHoliday([FromBody]Holiday pHoliday)
        {
            return loHoliday.updateHoliday(pHoliday);
        }

        [HttpGet]
        public bool removeHoliday(string pId, string pUserId)
        {
            return loHoliday.removeHoliday(pId, pUserId);
        }
        #endregion ""

        #region "Earning Type"
        [HttpGet]
        public DataTable getEarningTypes(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loEarningType.getEarningTypes(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertEarningType([FromBody]EarningType pEarningType)
        {
            return loEarningType.insertEarningType(pEarningType);
        }

        [HttpPost]
        public string updateEarningType([FromBody]EarningType pEarningType)
        {
            return loEarningType.updateEarningType(pEarningType);
        }

        [HttpGet]
        public bool removeEarningType(string pId, string pUserId)
        {
            return loEarningType.removeEarningType(pId, pUserId);
        }
        #endregion ""

        #region "Deduction Type"
        [HttpGet]
        public DataTable getDeductionTypes(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loDeductionType.getDeductionTypes(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertDeductionType([FromBody]DeductionType pDeductionType)
        {
            return loDeductionType.insertDeductionType(pDeductionType);
        }

        [HttpPost]
        public string updateDeductionType([FromBody]DeductionType pDeductionType)
        {
            return loDeductionType.updateDeductionType(pDeductionType);
        }

        [HttpGet]
        public bool removeDeductionType(string pId, string pUserId)
        {
            return loDeductionType.removeDeductionType(pId, pUserId);
        }
        #endregion ""

        #region "Tax Type"
        [HttpGet]
        public DataTable getTaxTypes(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loTaxType.getTaxTypes(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertTaxType([FromBody]TaxType pTaxType)
        {
            return loTaxType.insertTaxType(pTaxType);
        }

        [HttpPost]
        public string updateTaxType([FromBody]TaxType pTaxType)
        {
            return loTaxType.updateTaxType(pTaxType);
        }

        [HttpGet]
        public bool removeTaxType(string pId, string pUserId)
        {
            return loTaxType.removeTaxType(pId, pUserId);
        }
        #endregion ""

        #region "Income Tax Table"
        [HttpGet]
        public DataTable getIncomeTaxTables(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loIncomeTaxTable.getIncomeTaxTables(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertIncomeTaxTable([FromBody]IncomeTaxTable pIncomeTaxTable)
        {
            return loIncomeTaxTable.insertIncomeTaxTable(pIncomeTaxTable);
        }

        [HttpPost]
        public string updateIncomeTaxTable([FromBody]IncomeTaxTable pIncomeTaxTable)
        {
            return loIncomeTaxTable.updateIncomeTaxTable(pIncomeTaxTable);
        }

        [HttpGet]
        public bool removeIncomeTaxTable(string pId, string pUserId)
        {
            return loIncomeTaxTable.removeIncomeTaxTable(pId, pUserId);
        }
        #endregion ""

        #region "Work Schedules"
        [HttpGet]
        public DataTable getWorkSchedules(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loWorkSchedule.getWorkSchedules(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertWorkSchedule([FromBody]WorkSchedule pWorkSchedule)
        {
            return loWorkSchedule.insertWorkSchedule(pWorkSchedule);
        }

        [HttpPost]
        public string updateWorkSchedule([FromBody]WorkSchedule pWorkSchedule)
        {
            return loWorkSchedule.updateWorkSchedule(pWorkSchedule);
        }

        [HttpGet]
        public bool removeWorkSchedule(string pId, string pUserId)
        {
            return loWorkSchedule.removeWorkSchedule(pId, pUserId);
        }
        #endregion ""

        #region "Daily Time Records"

        public DataTable getDailyTimeRecordDates(string pEmployeeNo, DateTime pFromDate, DateTime pToDate)
        {
            return loDailyTimeRecord.getDailyTimeRecordDates(pEmployeeNo, pFromDate, pToDate);
        }

        public DataTable getDailyTimeRecordByDate(string pEmployeeNo, DateTime pFromDate, DateTime pToDate)
        {
            return loDailyTimeRecord.getDailyTimeRecordByDate(pEmployeeNo, pFromDate, pToDate);
        }

        [HttpGet]
        public bool insertTimeIn(string pDailyTimeRecordId, string pTimeIn, string pUsername, string pHostname)
        {
            return loDailyTimeRecord.insertTimeIn(pDailyTimeRecordId, pTimeIn, pUsername, pHostname);
        }

        [HttpGet]
        public bool insertBreakOut(string pDailyTimeRecordId, string pBreakOut, string pUsername, string pHostname)
        {
            return loDailyTimeRecord.insertBreakOut(pDailyTimeRecordId, pBreakOut, pUsername, pHostname);
        }

        [HttpGet]
        public bool insertBreakIn(string pDailyTimeRecordId, string pBreakIn, string pUsername, string pHostname)
        {
            return loDailyTimeRecord.insertBreakIn(pDailyTimeRecordId, pBreakIn, pUsername, pHostname);
        }

        [HttpGet]
        public bool insertTimeOut(string pDailyTimeRecordId, string pTimeOut, string pUsername, string pHostname)
        {
            return loDailyTimeRecord.insertTimeOut(pDailyTimeRecordId, pTimeOut, pUsername, pHostname);
        }
        
        [HttpGet]
        public bool insertLate1(string pDailyTimeRecordId, string pLate1, string pUsername, string pHostname)
        {
            return loDailyTimeRecord.insertLate1(pDailyTimeRecordId, pLate1, pUsername, pHostname);
        }

        [HttpGet]
        public bool insertLate2(string pDailyTimeRecordId, string pLate2, string pUsername, string pHostname)
        {
            return loDailyTimeRecord.insertLate2(pDailyTimeRecordId, pLate2, pUsername, pHostname);
        }

        [HttpGet]
        public bool insertUndertime1(string pDailyTimeRecordId, string pUndertime1, string pUsername, string pHostname)
        {
            return loDailyTimeRecord.insertUndertime1(pDailyTimeRecordId, pUndertime1, pUsername, pHostname);
        }

        [HttpGet]
        public bool insertUndertime2(string pDailyTimeRecordId, string pUndertime2, string pUsername, string pHostname)
        {
            return loDailyTimeRecord.insertUndertime2(pDailyTimeRecordId, pUndertime2, pUsername, pHostname);
        }

        [HttpPost]
        public bool updateDailyTimeRecord([FromBody]DailyTimeRecord pDailyTimeRecord)
        {
            return loDailyTimeRecord.updateDailyTimeRecord(pDailyTimeRecord);
        }

        [HttpGet]
        public DataTable updateDTRShiftSchedule(string pEmployeeNo, DateTime pFromDate, DateTime pToDate, string pShiftSchedule)
        {
            return loDailyTimeRecord.updateDTRShiftSchedule(pEmployeeNo, pFromDate, pToDate, pShiftSchedule);
        }

        #endregion

        #region "COA Entry"
        [HttpGet]
        public DataTable getCOAEntries(string pEmploymentTypeId, DateTime pFromDate, DateTime pToDate, string pSearchString, string pDepartmentId)
        {
            return loCOAEntry.getCOAEntries(pEmploymentTypeId, pFromDate, pToDate, pSearchString, pDepartmentId);
        }

        [HttpGet]
        public DataTable getCOAEntryStatus(string pCOAEntryId)
        {
            return loCOAEntry.getCOAEntryStatus(pCOAEntryId);
        }

        [HttpGet]
        public DataTable getCOAEntry(string pCOAEntryId)
        {
            return loCOAEntry.getCOAEntry(pCOAEntryId);
        }

        [HttpPost]
        public bool insertCOAEntry([FromBody] COAEntry pCOAEntry, string pUserId)
        {
            return loCOAEntry.insertCOAEntry(pCOAEntry, pUserId);
        }

        [HttpPost]
        public bool updateCOAEntry([FromBody] COAEntry pCOAEntry, string pUserId)
        {
            return loCOAEntry.updateCOAEntry(pCOAEntry, pUserId);
        }

        [HttpGet]
        public bool removeCOAEntry(string pCOAEntryId, string pUserId)
        {
            return loCOAEntry.removeCOAEntry(pCOAEntryId, pUserId);
        }

        [HttpGet]
        public bool approveCOAEntry(string pCOAEntryId, string pUserId)
        {
            return loCOAEntry.approveCOAEntry(pCOAEntryId, pUserId);
        }

        [HttpGet]
        public bool cancelCOAEntry(string pCOAEntryId, string pCancelReason, string pUserId)
        {
            return loCOAEntry.cancelCOAEntry(pCOAEntryId, pCancelReason, pUserId);
        }

        #endregion

        #region "Leave Entry"
        [HttpGet]
        public DataTable getLeaveEntries(string pEmploymentTypeId, DateTime pFromDate, DateTime pToDate, string pSearchString, string pDepartmentId)
        {
            return loLeaveEntry.getLeaveEntries(pEmploymentTypeId, pFromDate, pToDate, pSearchString, pDepartmentId);
        }

        [HttpGet]
        public DataTable getLeaveEntry(string pLeaveEntryId)
        {
            return loLeaveEntry.getLeaveEntry(pLeaveEntryId);
        }

        [HttpGet]
        public DataTable getLeaveEntryStatus(string pLeaveEntryId)
        {
            return loLeaveEntry.getLeaveEntryStatus(pLeaveEntryId);
        }

        [HttpPost]
        public bool insertLeaveEntry([FromBody] LeaveEntry loLeaveEntry, string pUserId)
        {
            return loLeaveEntry.insertLeaveEntry(loLeaveEntry, pUserId);
        }

        [HttpPost]
        public bool updateLeaveEntry([FromBody] LeaveEntry loLeaveEntry, string pUserId)
        {
            return loLeaveEntry.updateLeaveEntry(loLeaveEntry, pUserId);
        }

        [HttpGet]
        public bool approveLeaveEntry(string pLeaveEntryId, string pUserId)
        {
            return loLeaveEntry.approveLeaveEntry(pLeaveEntryId, pUserId);
        }

        [HttpGet]
        public bool approveLeaveEntryByDate(string pLeaveEntryId, DateTime pDate, string pUserId)
        {
            return loLeaveEntry.approveLeaveEntryByDate(pLeaveEntryId, pDate, pUserId);
        }

        [HttpGet]
        public bool cancelLeaveEntry(string pLeaveEntryId, string pCancelReason, string pUserId)
        {
            return loLeaveEntry.cancelLeaveEntry(pLeaveEntryId, pCancelReason, pUserId);
        }

        [HttpGet]
        public bool removeLeaveEntry(string pLeaveEntryId, string pUserId)
        {
            return loLeaveEntry.removeLeaveEntry(pLeaveEntryId, pUserId);
        }

        #endregion

        #region "Overtime Entry"
        [HttpGet]
        public DataTable getOvertimeEntryEmployeeList(string pEmploymentTypeId, DateTime pFromDate, DateTime pToDate,
                                    string pSearchString, string pDepartmentId)
        {
            return loOvertimeEntry.getOvertimeEntryEmployeeList(pEmploymentTypeId, pFromDate, pToDate, pSearchString, pDepartmentId);
        }

        [HttpGet]
        public DataTable getOvertimeEntries(string pEmploymentNo, DateTime pFromDate, DateTime pToDate)
        {
            return loOvertimeEntry.getOvertimeEntries(pEmploymentNo, pFromDate, pToDate);
        }

        [HttpGet]
        public DataTable getOvertimeEntryStatus(string pOvertimeEntryId)
        {
            return loOvertimeEntry.getOvertimeEntryStatus(pOvertimeEntryId);
        }

        [HttpGet]
        public DataTable getOvertimeEntry(string pOvertimeEntryId)
        {
            return loOvertimeEntry.getOvertimeEntry(pOvertimeEntryId);
        }

        [HttpPost]
        public bool insertOvertimeEntry([FromBody]OvertimeEntry pOvertimeEntry, string pUserId)
        {
            return loOvertimeEntry.insertOvertimeEntry(pOvertimeEntry, pUserId);
        }

        [HttpGet]
        public bool approveOvertimeEntry(string pOvertimeEntryId, string pUserId)
        {
            return loOvertimeEntry.approveOvertimeEntry(pOvertimeEntryId, pUserId);
        }

        [HttpGet]
        public bool cancelOvertimeEntry(string pOvertimeEntryId, string pCancelReason, string pUserId)
        {
            return loOvertimeEntry.cancelOvertimeEntry(pOvertimeEntryId, pCancelReason, pUserId);
        }

        [HttpGet]
        public bool removeOvertimeEntry(string pOvertimeEntryId, string pUserId)
        {
            return loOvertimeEntry.removeOvertimeEntry(pOvertimeEntryId, pUserId);
        }
        #endregion

        #region "Holiday Entry"
        [HttpGet]
        public DataTable getHolidayEntries()
        {
            return loHolidayEntry.getHolidayEntries();
        }

        [HttpGet]
        public DataTable getHolidayEntry(string pHolidayEntryId)
        {
            return loHolidayEntry.getHolidayEntry(pHolidayEntryId);
        }

        [HttpGet]
        public DataTable getHolidayEntryStatus(string pHolidayEntryId)
        {
            return loHolidayEntry.getHolidayEntryStatus(pHolidayEntryId);
        }

        [HttpPost]
        public bool insertHolidayEntry([FromBody]HolidayEntry pHolidayEntry, string pUserId)
        {
            return loHolidayEntry.insertHolidayEntry(pHolidayEntry, pUserId);
        }

        [HttpPost]
        public bool updateHolidayEntry([FromBody]HolidayEntry pHolidayEntry, string pUserId)
        {
            return loHolidayEntry.updateHolidayEntry(pHolidayEntry, pUserId);
        }

        [HttpGet]
        public bool approveHolidayEntry(string pHolidayEntryId, string pUserId)
        {
            return loHolidayEntry.approveHolidayEntry(pHolidayEntryId, pUserId);
        }

        [HttpGet]
        public bool cancelHolidayEntry(string pHolidayEntryId, string pCancelReason, string pUserId)
        {
            return loHolidayEntry.cancelHolidayEntry(pHolidayEntryId, pCancelReason, pUserId);
        }

        [HttpGet]
        public bool removeHolidayEntry(string pHolidayEntryId, string pUserId)
        {
            return loHolidayEntry.removeHolidayEntry(pHolidayEntryId, pUserId);
        }
        #endregion

        #endregion

        #region "PAYROLLS"

        #endregion

        #region "SYSTEMS"
        #region "Users"
        [HttpGet]
        public DataTable authenticateUser(string pUsername, string pPassword)
        {
            if (pPassword == null)
            {
                pPassword = "";
            }
            return loUser.authenticateUser(pUsername, pPassword);
        }

        [HttpGet]
        public DataTable getUsers(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loUser.getUsers(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public bool checkUserPassword(string pUserId, string pCurrentPassword)
        {
            return loUser.checkUserPassword(pUserId, pCurrentPassword);
        }

        [HttpGet]
        public bool changePassword(string pUserId,string pNewPassword)
        {
            return loUser.changePassword(pUserId, pNewPassword);
        }

        [HttpPost]
        public string insertUser([FromBody]User pUser)
        {
            return loUser.insertUser(pUser);
        }

        [HttpPost]
        public string updateUser([FromBody]User pUser)
        {
            return loUser.updateUser(pUser);
        }

        [HttpGet]
        public bool removeUser(string pId,string pUserId)
        {
            return loUser.removeUser(pId, pUserId);
        }
        #endregion ""

        #region "User Groups"
        [HttpGet]
        public DataTable getUserGroups(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loUserGroup.getUserGroups(pDisplayType,pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertUserGroup([FromBody]UserGroup pUserGroup)
        {
            return loUserGroup.insertUserGroup(pUserGroup);
        }

        [HttpPost]
        public string updateUserGroup([FromBody]UserGroup pUserGroup)
        {
            return loUserGroup.updateUserGroup(pUserGroup);
        }

        [HttpGet]
        public bool removeUserGroup(string pId, string pUserId)
        {
            return loUserGroup.removeUserGroup(pId, pUserId);
        }

        [HttpGet]
        public bool removeAllUserGroup(string pUserGroupId)
        {
            return loUserGroup.removeAllUserGroup(pUserGroupId);
        }

        [HttpGet]
        public bool updateUserGroupMenuItems(string pUserGroupId, string pMenuItem, string pItemName)
        {
            return loUserGroup.updateUserGroupMenuItems(pUserGroupId, pMenuItem, pItemName);
        }

        [HttpGet]
        public bool removeAllRights(string pUserGroupId, string pItemName)
        {
            return loUserGroup.removeAllRights(pUserGroupId, pItemName);
        }

        [HttpGet]
        public bool updateUserGroupRights(string pUserGroupId, string pItemName, string pRights)
        {
            return loUserGroup.updateUserGroupRights(pUserGroupId, pItemName, pRights);
        }
        #endregion ""

        #region "System Configurations"
        [HttpGet]
        public DataTable getSystemConfigurations()
        {
            return loSystemConfigurations.getSystemConfigurations();
        }

        [HttpPost]
        public bool updateSystemConfiguration([FromBody]SystemConfiguration pSystemConfiguration)
        {
            return loSystemConfigurations.updateSystemConfiguration(pSystemConfiguration);
        }
        #endregion ""

        #region "Audit Trail"
        [HttpGet]
        public DataTable getAuditTrailByDate(DateTime pFrom, DateTime pTo)
        {
            return loAuditTrail.getAuditTrailByDate(pFrom, pTo);
        }

        [HttpGet]
        public bool removeAuditTrail(DateTime pFrom, DateTime pTo)
        {
            return loAuditTrail.removeAuditTrail(pFrom, pTo);
        }
        #endregion ""

        #region "Backup / Restore Database"
        [HttpGet]
        public bool backupDatabase(string pSaveFileTo, string pBackupMySqlDumpAddress,
            string pUserId, string pPassword, string pServer, string pDatabase)
        {
            return loCommon.backupDatabase(pSaveFileTo, pBackupMySqlDumpAddress, pUserId, pPassword, pServer, pDatabase);
        }

        [HttpGet]
        public bool restoreDatabase(string pSQLFileFrom, string pRestoreMySqlAddress,
            string pUserId, string pPassword, string pServer, string pDatabase)
        {
            return loCommon.restoreDatabase(pSQLFileFrom, pRestoreMySqlAddress, pUserId, pPassword, pServer, pDatabase);
        }

        #endregion ""

        #endregion
    }
}
