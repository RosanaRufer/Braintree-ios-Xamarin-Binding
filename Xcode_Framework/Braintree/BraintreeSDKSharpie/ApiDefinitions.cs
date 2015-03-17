using System;
using Foundation;

namespace BraintreeBindingiOS
{
	// @interface BTPaymentMethod : NSObject
	[BaseType (typeof(NSObject))]
	interface BTPaymentMethod
	{
		// @property (readonly, copy, nonatomic) NSString * nonce;
		[Export ("nonce")]
		string Nonce { get; }
	}

	// @interface BTCardPaymentMethod : BTPaymentMethod
	[BaseType (typeof(BTPaymentMethod))]
	interface BTCardPaymentMethod
	{
		// @property (readonly, assign, nonatomic) BTCardType type;
		[Export ("type", ArgumentSemantic.Assign)]
		BTCardType Type { get; }

		// @property (readonly, copy, nonatomic) NSString * typeString;
		[Export ("typeString")]
		string TypeString { get; }

		// @property (readonly, copy, nonatomic) NSString * lastTwo;
		[Export ("lastTwo")]
		string LastTwo { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * threeDSecureInfo;
		[Export ("threeDSecureInfo", ArgumentSemantic.Copy)]
		NSDictionary ThreeDSecureInfo { get; }
	}

	// @interface BTPayPalPaymentMethod : BTPaymentMethod <NSMutableCopying>
	[BaseType (typeof(BTPaymentMethod))]
	interface BTPayPalPaymentMethod : INSMutableCopying
	{
		// @property (readonly, copy, nonatomic) NSString * email;
		[Export ("email")]
		string Email { get; }
	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const BTBraintreeAPIErrorDomain;
		[Field ("BTBraintreeAPIErrorDomain")]
		NSString BTBraintreeAPIErrorDomain { get; }

		// extern enum BTErrorCode BTErrorCode;
		[Field ("BTErrorCode")]
		BTErrorCode BTErrorCode { get; }
	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const BTCustomerInputBraintreeValidationErrorsKey;
		[Field ("BTCustomerInputBraintreeValidationErrorsKey")]
		NSString BTCustomerInputBraintreeValidationErrorsKey { get; }

		// extern NSString * BTThreeDSecureInfoKey;
		[Field ("BTThreeDSecureInfoKey")]
		NSString BTThreeDSecureInfoKey { get; }
	}

	// @interface BTClientCardTokenizationRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface BTClientCardTokenizationRequest
	{
		// @property (copy, nonatomic) NSString * number;
		[Export ("number")]
		string Number { get; set; }

		// @property (copy, nonatomic) NSString * expirationMonth;
		[Export ("expirationMonth")]
		string ExpirationMonth { get; set; }

		// @property (copy, nonatomic) NSString * expirationYear;
		[Export ("expirationYear")]
		string ExpirationYear { get; set; }

		// @property (copy, nonatomic) NSString * expirationDate;
		[Export ("expirationDate")]
		string ExpirationDate { get; set; }

		// @property (copy, nonatomic) NSString * cvv;
		[Export ("cvv")]
		string Cvv { get; set; }

		// @property (copy, nonatomic) NSString * postalCode;
		[Export ("postalCode")]
		string PostalCode { get; set; }

		// @property (readonly, assign, nonatomic) BOOL shouldValidate;
		[Export ("shouldValidate")]
		bool ShouldValidate { get; }

		// @property (nonatomic, strong) NSDictionary * additionalParameters;
		[Export ("additionalParameters", ArgumentSemantic.Strong)]
		NSDictionary AdditionalParameters { get; set; }

		// -(NSDictionary *)parameters;
		[Export ("parameters")]
		[Verify (MethodToProperty)]
		NSDictionary Parameters { get; }
	}

	// @interface BTClientCardRequest : BTClientCardTokenizationRequest
	[BaseType (typeof(BTClientCardTokenizationRequest))]
	interface BTClientCardRequest
	{
		// @property (assign, readwrite, nonatomic) BOOL shouldValidate;
		[Export ("shouldValidate")]
		bool ShouldValidate { get; set; }

		// -(instancetype)initWithTokenizationRequest:(BTClientCardTokenizationRequest *)tokenizationRequest;
		[Export ("initWithTokenizationRequest:")]
		IntPtr Constructor (BTClientCardTokenizationRequest tokenizationRequest);
	}

	// typedef void (^BTClientPaymentMethodListSuccessBlock)(NSArray *);
	delegate void BTClientPaymentMethodListSuccessBlock (NSObject[] arg0);

	// typedef void (^BTClientPaymentMethodSuccessBlock)(BTPaymentMethod *);
	delegate void BTClientPaymentMethodSuccessBlock (BTPaymentMethod arg0);

	// typedef void (^BTClientCardSuccessBlock)(BTCardPaymentMethod *);
	delegate void BTClientCardSuccessBlock (BTCardPaymentMethod arg0);

	// typedef void (^BTClientPaypalSuccessBlock)(BTPayPalPaymentMethod *);
	delegate void BTClientPaypalSuccessBlock (BTPayPalPaymentMethod arg0);

	// typedef void (^BTClientAnalyticsSuccessBlock)();
	delegate void BTClientAnalyticsSuccessBlock ();

	// typedef void (^BTClientFailureBlock)(NSError *);
	delegate void BTClientFailureBlock (NSError arg0);

	// @interface BTClient : NSObject <NSCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface BTClient : INSCoding, INSCopying
	{
		// -(instancetype)initWithClientToken:(NSString *)clientTokenString;
		[Export ("initWithClientToken:")]
		IntPtr Constructor (string clientTokenString);

		// @property (readonly, nonatomic) NSSet * challenges;
		[Export ("challenges")]
		NSSet Challenges { get; }

		// @property (readonly, copy, nonatomic) NSString * merchantId;
		[Export ("merchantId")]
		string MerchantId { get; }

		// -(void)fetchPaymentMethodsWithSuccess:(BTClientPaymentMethodListSuccessBlock)successBlock failure:(BTClientFailureBlock)failureBlock;
		[Export ("fetchPaymentMethodsWithSuccess:failure:")]
		void FetchPaymentMethodsWithSuccess (BTClientPaymentMethodListSuccessBlock successBlock, BTClientFailureBlock failureBlock);

		// -(void)fetchPaymentMethodWithNonce:(NSString *)nonce success:(BTClientPaymentMethodSuccessBlock)successBlock failure:(BTClientFailureBlock)failureBlock;
		[Export ("fetchPaymentMethodWithNonce:success:failure:")]
		void FetchPaymentMethodWithNonce (string nonce, BTClientPaymentMethodSuccessBlock successBlock, BTClientFailureBlock failureBlock);

		// -(void)saveCardWithRequest:(BTClientCardRequest *)request success:(BTClientCardSuccessBlock)successBlock failure:(BTClientFailureBlock)failureBlock;
		[Export ("saveCardWithRequest:success:failure:")]
		void SaveCardWithRequest (BTClientCardRequest request, BTClientCardSuccessBlock successBlock, BTClientFailureBlock failureBlock);

		// -(void)savePaypalPaymentMethodWithAuthCode:(NSString *)authCode applicationCorrelationID:(NSString *)applicationCorrelationId success:(BTClientPaypalSuccessBlock)successBlock failure:(BTClientFailureBlock)failureBlock;
		[Export ("savePaypalPaymentMethodWithAuthCode:applicationCorrelationID:success:failure:")]
		void SavePaypalPaymentMethodWithAuthCode (string authCode, string applicationCorrelationId, BTClientPaypalSuccessBlock successBlock, BTClientFailureBlock failureBlock);

		// -(void)savePaypalPaymentMethodWithAuthCode:(NSString *)authCode success:(BTClientPaypalSuccessBlock)successBlock failure:(BTClientFailureBlock)failureBlock __attribute__((deprecated("")));
		[Export ("savePaypalPaymentMethodWithAuthCode:success:failure:")]
		void SavePaypalPaymentMethodWithAuthCode (string authCode, BTClientPaypalSuccessBlock successBlock, BTClientFailureBlock failureBlock);

		// -(void)savePaypalPaymentMethodWithAuthCode:(NSString *)authCode correlationId:(NSString *)correlationId success:(BTClientPaypalSuccessBlock)successBlock failure:(BTClientFailureBlock)failureBlock __attribute__((deprecated("")));
		[Export ("savePaypalPaymentMethodWithAuthCode:correlationId:success:failure:")]
		void SavePaypalPaymentMethodWithAuthCode (string authCode, string correlationId, BTClientPaypalSuccessBlock successBlock, BTClientFailureBlock failureBlock);

		// -(void)postAnalyticsEvent:(NSString *)eventKind success:(BTClientAnalyticsSuccessBlock)successBlock failure:(BTClientFailureBlock)failureBlock;
		[Export ("postAnalyticsEvent:success:failure:")]
		void PostAnalyticsEvent (string eventKind, BTClientAnalyticsSuccessBlock successBlock, BTClientFailureBlock failureBlock);

		// -(void)postAnalyticsEvent:(NSString *)eventKind;
		[Export ("postAnalyticsEvent:")]
		void PostAnalyticsEvent (string eventKind);

		// +(NSString *)libraryVersion;
		[Static]
		[Export ("libraryVersion")]
		[Verify (MethodToProperty)]
		string LibraryVersion { get; }
	}
}
