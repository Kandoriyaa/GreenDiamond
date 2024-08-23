namespace GreenDiamond.Application.Helper
{
    public class GlobalDeclaration
    {
        // Pagination Para
        public static readonly int page = 1;
        public static readonly int pageSize = 10;

        // Messages
        public static readonly string _internalServerError = "Something went wrong, Please try after sometime.";

        public static readonly string _retriveResponse = "Data retrived successful!";
        public static readonly string _recordNotFound = "Record not found!";
        public static readonly string _emailExists = "Email is already exists, Please choose different.";
        public static readonly string _savedResponse = "Record has been saved successfully.";
        public static readonly string _loginResponse = "Login successfully.";
        public static readonly string _logoutResponse = "Logout successfully.";
        public static readonly string _deletedResponse = "Record has been deleted successfully.";
        public static readonly string _superUserdeletedResponse = "You can not delete super user.";
        public static readonly string _invalidLoginResponse = "Email address or password dose not match, Try again.";
        public static readonly string _supserUserResponse = "You are unauthorized.";
        public static readonly string _invalidFileExtResponse = "File extension is invalid.";

        public static readonly string _companyExists = "Company name is already exists, Please choose different.";
        public static readonly string _OtpDescExists = "OTP Description is already exists, Please choose different.";
        public static readonly string _roleExists = "Role name is already exists, Please choose different.";
        public static readonly string _cityExists = "City name is already exists, Please choose different.";
        public static readonly string _stateExists = "State name is already exists, Please choose different.";
        public static readonly string _countryExists = "Country name is already exists, Please choose different.";
        public static readonly string _moduleExists = "Modul name is already exists, Please choose different.";
        public static readonly string _permissionExists = "Permission name is already exists, Please choose different.";
        public static readonly string _atLeastOnePermissionResponse = "Please select at least one permission.";
        public static readonly string _companySelectResponse = "You are not allow to select multiple companies. Please select one.";
        public static readonly string _companyNotConfigurResponse = "Company is not configure with this account, Please contact admin.";

		public static readonly string _tenantExists = "Tenant name is already exists, Please choose different.";
		public static readonly string _tenantAdminExists = "Tenant admin is already exists, Please choose different.";
		public static readonly string _tenantLicenceExists = "Tenant Licence is already exists, Please choose different.";
		public static readonly string _invalidLicenceResponse = " Your Woopsa ERP Licence has either expired or not been activated, please contact support.";
        public static readonly string _manufacturerprogramId = "Program Id Cannot Allow More Than 2 Characters.";
    }
}