using ObjCRuntime;

namespace BraintreeBindingiOS
{
	[Native]
	public enum BTCardType : long
	{
		Unknown = 0L,
		Amex,
		DinersClub,
		Discover,
		MasterCard,
		Visa,
		Jcb,
		Laser,
		Maestro,
		UnionPay,
		Solo,
		Switch,
		UKMaestro
	}

	[Native]
	public enum BTErrorCode : long
	{
		UnknownError = 0L,
		CustomerInputErrorUnknown,
		CustomerInputErrorInvalid,
		MerchantIntegrationErrorUnauthorized,
		MerchantIntegrationErrorNotFound,
		MerchantIntegrationErrorInvalidClientToken,
		MerchantIntegrationErrorNonceNotFound,
		ServerErrorUnknown,
		ServerErrorGatewayUnavailable,
		ServerErrorNetworkUnavailable,
		ServerErrorSSL,
		ServerErrorUnexpectedError,
		ErrorUnsupported
	}
}
