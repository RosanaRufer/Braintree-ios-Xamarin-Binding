using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

using Darwin;

namespace BraintreeBinding
{
	// @interface BTAPIPinnedCertificates : NSObject
	[BaseType (typeof(NSObject))]
	interface BTAPIPinnedCertificates
	{
		// +(NSArray *)trustedCertificates;
		[Static]
		[Export ("trustedCertificates")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] TrustedCertificates { get; }
	}

	// @protocol BTValueTransforming <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTValueTransforming
	{
		// @required -(id)transformedValue:(id)value;
		[Abstract]
		[Export ("transformedValue:")]
		NSObject TransformedValue (NSObject value);
	}

	// @interface BTAPIResponseParser : NSObject <NSCopying, NSCoding>
	[BaseType (typeof(NSObject))]
	interface BTAPIResponseParser : INSCopying, INSCoding
	{
		// +(instancetype)parserWithDictionary:(NSDictionary *)dictionary;
		[Static]
		[Export ("parserWithDictionary:")]
		BTAPIResponseParser ParserWithDictionary (NSDictionary dictionary);

		// -(instancetype)initWithDictionary:(NSDictionary *)dictionary __attribute__((objc_designated_initializer));
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// -(NSString *)stringForKey:(NSString *)key;
		[Export ("stringForKey:")]
		string StringForKey (string key);

		// -(NSArray *)arrayForKey:(NSString *)key;
		[Export ("arrayForKey:")]
		[Verify (StronglyTypedNSArray)]
		NSObject[] ArrayForKey (string key);

		// -(NSSet *)setForKey:(NSString *)key;
		[Export ("setForKey:")]
		NSSet SetForKey (string key);

		// -(NSDictionary *)dictionaryForKey:(NSString *)key;
		[Export ("dictionaryForKey:")]
		NSDictionary DictionaryForKey (string key);

		// -(NSURL *)URLForKey:(NSString *)key;
		[Export ("URLForKey:")]
		NSURL URLForKey (string key);

		// -(BTAPIResponseParser *)responseParserForKey:(NSString *)key;
		[Export ("responseParserForKey:")]
		BTAPIResponseParser ResponseParserForKey (string key);

		// -(id)objectForKey:(NSString *)key withValueTransformer:(id<BTValueTransforming>)valueTransformer;
		[Export ("objectForKey:withValueTransformer:")]
		NSObject ObjectForKey (string key, BTValueTransforming valueTransformer);

		// -(NSArray *)arrayForKey:(NSString *)key withValueTransformer:(id<BTValueTransforming>)valueTransformer;
		[Export ("arrayForKey:withValueTransformer:")]
		[Verify (StronglyTypedNSArray)]
		NSObject[] ArrayForKey (string key, BTValueTransforming valueTransformer);

		// -(NSInteger)integerForKey:(NSString *)key withValueTransformer:(id<BTValueTransforming>)valueTransformer;
		[Export ("integerForKey:withValueTransformer:")]
		nint IntegerForKey (string key, BTValueTransforming valueTransformer);

		// -(BOOL)boolForKey:(NSString *)key withValueTransformer:(id<BTValueTransforming>)valueTransformer;
		[Export ("boolForKey:withValueTransformer:")]
		bool BoolForKey (string key, BTValueTransforming valueTransformer);
	}

	// @interface BTAnalyticsMetadata : NSObject
	[BaseType (typeof(NSObject))]
	interface BTAnalyticsMetadata
	{
		// +(NSDictionary *)metadata;
		[Static]
		[Export ("metadata")]
		[Verify (MethodToProperty)]
		NSDictionary Metadata { get; }
	}

	// @interface BTPaymentMethod : NSObject
	[BaseType (typeof(NSObject))]
	interface BTPaymentMethod
	{
		// @property (readonly, copy, nonatomic) NSString * nonce;
		[Export ("nonce")]
		string Nonce { get; set; }

		// @property (getter = isLocked, assign, readwrite, nonatomic) BOOL locked;
		[Export ("locked")]
		bool Locked { [Bind ("isLocked")] get; set; }

		// @property (readwrite, nonatomic, strong) NSSet * challengeQuestions;
		[Export ("challengeQuestions", ArgumentSemantic.Strong)]
		NSSet ChallengeQuestions { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * description;
		[Export ("description")]
		string Description { get; set; }
	}

	// @interface BTCardPaymentMethod : BTPaymentMethod
	[BaseType (typeof(BTPaymentMethod))]
	interface BTCardPaymentMethod
	{
		// @property (readonly, assign, nonatomic) BTCardType type;
		[Export ("type", ArgumentSemantic.Assign)]
		BTCardType Type { get; set; }

		// @property (readonly, copy, nonatomic) NSString * typeString;
		[Export ("typeString")]
		string TypeString { get; set; }

		// @property (readonly, copy, nonatomic) NSString * lastTwo;
		[Export ("lastTwo")]
		string LastTwo { get; set; }

		// @property (readonly, copy, nonatomic) NSDictionary * threeDSecureInfo;
		[Export ("threeDSecureInfo", ArgumentSemantic.Copy)]
		NSDictionary ThreeDSecureInfo { get; set; }
	}

	// @interface BTPayPalPaymentMethod : BTPaymentMethod <NSMutableCopying>
	[BaseType (typeof(BTPaymentMethod))]
	interface BTPayPalPaymentMethod : INSMutableCopying
	{
		// @property (readonly, copy, nonatomic) NSString * email;
		[Export ("email")]
		string Email { get; set; }
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

		// @property (readwrite, nonatomic, strong) BTHTTP * clientApiHttp;
		[Export ("clientApiHttp", ArgumentSemantic.Strong)]
		BTHTTP ClientApiHttp { get; set; }

		// @property (readwrite, nonatomic, strong) BTHTTP * analyticsHttp;
		[Export ("analyticsHttp", ArgumentSemantic.Strong)]
		BTHTTP AnalyticsHttp { get; set; }

		// @property (nonatomic, strong) BTClientToken * clientToken;
		[Export ("clientToken", ArgumentSemantic.Strong)]
		BTClientToken ClientToken { get; set; }

		// @property (readonly, copy, nonatomic) BTClientMetadata * metadata;
		[Export ("metadata", ArgumentSemantic.Copy)]
		BTClientMetadata Metadata { get; }
	}

	// @protocol BTAppSwitching <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface BTAppSwitching
//	{
//	}

	// @protocol BTAppSwitchingDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTAppSwitchingDelegate
	{
		// @optional -(void)appSwitcherWillCreatePaymentMethod:(id<BTAppSwitching>)switcher;
		[Export ("appSwitcherWillCreatePaymentMethod:")]
		void AppSwitcherWillCreatePaymentMethod (BTAppSwitching switcher);

		// @required -(void)appSwitcher:(id<BTAppSwitching>)switcher didCreatePaymentMethod:(BTPaymentMethod *)paymentMethod;
		[Abstract]
		[Export ("appSwitcher:didCreatePaymentMethod:")]
		void AppSwitcher (BTAppSwitching switcher, BTPaymentMethod paymentMethod);

		// @required -(void)appSwitcher:(id<BTAppSwitching>)switcher didFailWithError:(NSError *)error;
		[Abstract]
		[Export ("appSwitcher:didFailWithError:")]
		void AppSwitcher (BTAppSwitching switcher, NSError error);

		// @required -(void)appSwitcherDidCancel:(id<BTAppSwitching>)switcher;
		[Abstract]
		[Export ("appSwitcherDidCancel:")]
		void AppSwitcherDidCancel (BTAppSwitching switcher);
	}

	// @protocol BTAppSwitching <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTAppSwitching
	{
		// @required @property (copy, nonatomic) NSString * returnURLScheme;
		[Export ("returnURLScheme")]
		string ReturnURLScheme { get; set; }

		[Wrap ("WeakDelegate")]
		BTAppSwitchingDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<BTAppSwitchingDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @required -(BOOL)appSwitchAvailableForClient:(BTClient *)client;
		[Abstract]
		[Export ("appSwitchAvailableForClient:")]
		bool AppSwitchAvailableForClient (BTClient client);

		// @required -(BOOL)initiateAppSwitchWithClient:(BTClient *)client delegate:(id<BTAppSwitchingDelegate>)delegate error:(NSError **)error;
		[Abstract]
		[Export ("initiateAppSwitchWithClient:delegate:error:")]
		bool InitiateAppSwitchWithClient (BTClient client, BTAppSwitchingDelegate @delegate, out NSError error);

		// @required -(BOOL)canHandleReturnURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication;
		[Abstract]
		[Export ("canHandleReturnURL:sourceApplication:")]
		bool CanHandleReturnURL (NSURL url, string sourceApplication);

		// @required -(void)handleReturnURL:(NSURL *)url;
		[Abstract]
		[Export ("handleReturnURL:")]
		void HandleReturnURL (NSURL url);
	}

	// @interface BTAppSwitch : NSObject
	[BaseType (typeof(NSObject))]
	interface BTAppSwitch
	{
		// @property (readwrite, copy, nonatomic) NSString * returnURLScheme;
		[Export ("returnURLScheme")]
		string ReturnURLScheme { get; set; }

		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		BTAppSwitch SharedInstance ();

		// -(BOOL)handleReturnURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication;
		[Export ("handleReturnURL:sourceApplication:")]
		bool HandleReturnURL (NSURL url, string sourceApplication);

		// -(void)addAppSwitching:(id<BTAppSwitching>)appSwitching;
		[Export ("addAppSwitching:")]
		void AddAppSwitching (BTAppSwitching appSwitching);

		// -(void)removeAppSwitching:(id<BTAppSwitching>)appSwitching;
		[Export ("removeAppSwitching:")]
		void RemoveAppSwitching (BTAppSwitching appSwitching);
	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const BTAppSwitchErrorDomain;
		[Field ("BTAppSwitchErrorDomain")]
		NSString BTAppSwitchErrorDomain { get; }

		// extern enum BTAppSwitchErrorCode BTAppSwitchErrorCode;
		[Field ("BTAppSwitchErrorCode")]
		BTAppSwitchErrorCode BTAppSwitchErrorCode { get; }
	}

	// @interface  (BTCardPaymentMethod)
	[Category]
	[BaseType (typeof(BTCardPaymentMethod))]
	interface BTCardPaymentMethod_
	{
		// @property (assign, readwrite, nonatomic) BTCardType type;
		[Export ("type")]
		BTCardType Type { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * typeString;
		[Export ("typeString")]
		string TypeString { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * lastTwo;
		[Export ("lastTwo")]
		string LastTwo { get; set; }

		// @property (readwrite, copy, nonatomic) NSDictionary * threeDSecureInfo;
		[Export ("threeDSecureInfo")]
		NSDictionary ThreeDSecureInfo { get; set; }
	}

	// @interface PayPalProfileSharingViewController : UINavigationController
	[BaseType (typeof(UINavigationController))]
	interface PayPalProfileSharingViewController
	{
	}

	// @interface PayPalConfiguration : NSObject <NSCopying>
//	[BaseType (typeof(NSObject))]
//	interface PayPalConfiguration : INSCopying
//	{
//	}

	// @protocol PayPalProfileSharingDelegate <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface PayPalProfileSharingDelegate
//	{
//	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const BTClientPayPalMobileEnvironmentName;
		[Field ("BTClientPayPalMobileEnvironmentName")]
		NSString BTClientPayPalMobileEnvironmentName { get; }
	}

	// @interface BTPayPal (BTClient)
	[Category]
	[BaseType (typeof(BTClient))]
	interface BTClient_BTPayPal
	{
		// +(NSString *)btPayPal_offlineTestClientToken;
		[Static]
		[Export ("btPayPal_offlineTestClientToken")]
		[Verify (MethodToProperty)]
		string BtPayPal_offlineTestClientToken { get; }

		// -(BOOL)btPayPal_preparePayPalMobileWithError:(NSError **)error;
		[Export ("btPayPal_preparePayPalMobileWithError:")]
		bool BtPayPal_preparePayPalMobileWithError (out NSError error);

		// -(BOOL)btPayPal_isPayPalEnabled;
		[Export ("btPayPal_isPayPalEnabled")]
		[Verify (MethodToProperty)]
		bool BtPayPal_isPayPalEnabled { get; }

		// -(PayPalProfileSharingViewController *)btPayPal_profileSharingViewControllerWithDelegate:(id<PayPalProfileSharingDelegate>)delegate;
		[Export ("btPayPal_profileSharingViewControllerWithDelegate:")]
		PayPalProfileSharingViewController BtPayPal_profileSharingViewControllerWithDelegate (PayPalProfileSharingDelegate @delegate);

		// -(NSString *)btPayPal_applicationCorrelationId;
		[Export ("btPayPal_applicationCorrelationId")]
		[Verify (MethodToProperty)]
		string BtPayPal_applicationCorrelationId { get; }

		// -(PayPalConfiguration *)btPayPal_configuration;
		[Export ("btPayPal_configuration")]
		[Verify (MethodToProperty)]
		PayPalConfiguration BtPayPal_configuration { get; }

		// -(NSString *)btPayPal_environment;
		[Export ("btPayPal_environment")]
		[Verify (MethodToProperty)]
		string BtPayPal_environment { get; }

		// -(BOOL)btPayPal_isTouchDisabled;
		[Export ("btPayPal_isTouchDisabled")]
		[Verify (MethodToProperty)]
		bool BtPayPal_isTouchDisabled { get; }

		// -(NSSet *)btPayPal_scopes;
		[Export ("btPayPal_scopes")]
		[Verify (MethodToProperty)]
		NSSet BtPayPal_scopes { get; }
	}

	// @interface BTVenmo (BTClient)
	[Category]
	[BaseType (typeof(BTClient))]
	interface BTClient_BTVenmo
	{
		// -(BTVenmoStatus)btVenmo_status;
		[Export ("btVenmo_status")]
		[Verify (MethodToProperty)]
		BTVenmoStatus BtVenmo_status { get; }
	}

	// @interface Offline (BTClient)
	[Category]
	[BaseType (typeof(BTClient))]
	interface BTClient_Offline
	{
		// +(NSString *)offlineTestClientTokenWithAdditionalParameters:(NSDictionary *)configuration;
		[Static]
		[Export ("offlineTestClientTokenWithAdditionalParameters:")]
		string OfflineTestClientTokenWithAdditionalParameters (NSDictionary configuration);
	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString * BTClientTestConfigurationKeyMerchantIdentifier;
		[Field ("BTClientTestConfigurationKeyMerchantIdentifier")]
		NSString BTClientTestConfigurationKeyMerchantIdentifier { get; }

		// extern NSString * BTClientTestConfigurationKeyPublicKey;
		[Field ("BTClientTestConfigurationKeyPublicKey")]
		NSString BTClientTestConfigurationKeyPublicKey { get; }

		// extern NSString * BTClientTestConfigurationKeyCustomer;
		[Field ("BTClientTestConfigurationKeyCustomer")]
		NSString BTClientTestConfigurationKeyCustomer { get; }

		// extern NSString * BTClientTestConfigurationKeySharedCustomerIdentifier;
		[Field ("BTClientTestConfigurationKeySharedCustomerIdentifier")]
		NSString BTClientTestConfigurationKeySharedCustomerIdentifier { get; }

		// extern NSString * BTClientTestConfigurationKeySharedCustomerIdentifierType;
		[Field ("BTClientTestConfigurationKeySharedCustomerIdentifierType")]
		NSString BTClientTestConfigurationKeySharedCustomerIdentifierType { get; }

		// extern NSString * BTClientTestConfigurationKeyRevoked;
		[Field ("BTClientTestConfigurationKeyRevoked")]
		NSString BTClientTestConfigurationKeyRevoked { get; }

		// extern NSString * BTClientTestConfigurationKeyClientTokenVersion;
		[Field ("BTClientTestConfigurationKeyClientTokenVersion")]
		NSString BTClientTestConfigurationKeyClientTokenVersion { get; }

		// extern NSString * BTClientTestConfigurationKeyAnalytics;
		[Field ("BTClientTestConfigurationKeyAnalytics")]
		NSString BTClientTestConfigurationKeyAnalytics { get; }

		// extern NSString * BTClientTestConfigurationKeyURL;
		[Field ("BTClientTestConfigurationKeyURL")]
		NSString BTClientTestConfigurationKeyURL { get; }

		// extern NSString * BTClientTestConfigurationKeyMerchantAccountIdentifier;
		[Field ("BTClientTestConfigurationKeyMerchantAccountIdentifier")]
		NSString BTClientTestConfigurationKeyMerchantAccountIdentifier { get; }
	}

	// typedef void (^BTClientNonceInfoSuccessBlock)(NSDictionary *);
	delegate void BTClientNonceInfoSuccessBlock (NSDictionary arg0);

	// @interface Testing (BTClient)
	[Category]
	[BaseType (typeof(BTClient))]
	interface BTClient_Testing
	{
		// +(void)testClientWithConfiguration:(NSDictionary *)configurationDictionary completion:(void (^)(BTClient *))block;
		[Static]
		[Export ("testClientWithConfiguration:completion:")]
		void TestClientWithConfiguration (NSDictionary configurationDictionary, Action<BTClient> block);

		// -(void)fetchNonceInfo:(NSString *)nonce success:(BTClientNonceInfoSuccessBlock)successBlock failure:(BTClientFailureBlock)failureBlock;
		[Export ("fetchNonceInfo:success:failure:")]
		void FetchNonceInfo (string nonce, BTClientNonceInfoSuccessBlock successBlock, BTClientFailureBlock failureBlock);

		// -(void)fetchNonceThreeDSecureVerificationInfo:(NSString *)nonce success:(BTClientNonceInfoSuccessBlock)successBlock failure:(BTClientFailureBlock)failureBlock;
		[Export ("fetchNonceThreeDSecureVerificationInfo:success:failure:")]
		void FetchNonceThreeDSecureVerificationInfo (string nonce, BTClientNonceInfoSuccessBlock successBlock, BTClientFailureBlock failureBlock);
	}

	// @interface BTClientMetadata : NSObject <NSCopying, NSMutableCopying>
	[BaseType (typeof(NSObject))]
	interface BTClientMetadata : INSCopying, INSMutableCopying
	{
		// @property (readonly, assign, nonatomic) BTClientMetadataIntegrationType integration;
		[Export ("integration", ArgumentSemantic.Assign)]
		BTClientMetadataIntegrationType Integration { get; }

		// @property (readonly, assign, nonatomic) BTClientMetadataSourceType source;
		[Export ("source", ArgumentSemantic.Assign)]
		BTClientMetadataSourceType Source { get; }

		// @property (readonly, copy, nonatomic) NSString * integrationString;
		[Export ("integrationString")]
		string IntegrationString { get; }

		// @property (readonly, copy, nonatomic) NSString * sourceString;
		[Export ("sourceString")]
		string SourceString { get; }
	}

	// @interface BTClientMutableMetadata : BTClientMetadata
	[BaseType (typeof(BTClientMetadata))]
	interface BTClientMutableMetadata
	{
		// -(void)setIntegration:(BTClientMetadataIntegrationType)integration;
		[Export ("setIntegration:")]
		void SetIntegration (BTClientMetadataIntegrationType integration);

		// -(void)setSource:(BTClientMetadataSourceType)source;
		[Export ("setSource:")]
		void SetSource (BTClientMetadataSourceType source);
	}

	// @interface BTClientPaymentMethodValueTransformer : NSObject <BTValueTransforming>
	[BaseType (typeof(NSObject))]
	interface BTClientPaymentMethodValueTransformer : IBTValueTransforming
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		BTClientPaymentMethodValueTransformer SharedInstance ();
	}

	// @interface BTClientStore : NSObject
	[BaseType (typeof(NSObject))]
	interface BTClientStore
	{
		// -(instancetype)initWithIdentifier:(NSString *)identifier;
		[Export ("initWithIdentifier:")]
		IntPtr Constructor (string identifier);

		// -(void)storeClient:(BTClient *)client;
		[Export ("storeClient:")]
		void StoreClient (BTClient client);

		// -(BTClient *)fetchClient;
		[Export ("fetchClient")]
		[Verify (MethodToProperty)]
		BTClient FetchClient { get; }
	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const BTClientTokenKeyAuthorizationFingerprint;
		[Field ("BTClientTokenKeyAuthorizationFingerprint")]
		NSString BTClientTokenKeyAuthorizationFingerprint { get; }

		// extern NSString *const BTClientTokenKeyClientApiURL;
		[Field ("BTClientTokenKeyClientApiURL")]
		NSString BTClientTokenKeyClientApiURL { get; }

		// extern NSString *const BTClientTokenKeyConfigURL;
		[Field ("BTClientTokenKeyConfigURL")]
		NSString BTClientTokenKeyConfigURL { get; }

		// extern NSString *const BTClientTokenKeyChallenges;
		[Field ("BTClientTokenKeyChallenges")]
		NSString BTClientTokenKeyChallenges { get; }

		// extern NSString *const BTClientTokenKeyAnalytics;
		[Field ("BTClientTokenKeyAnalytics")]
		NSString BTClientTokenKeyAnalytics { get; }

		// extern NSString *const BTClientTokenKeyURL;
		[Field ("BTClientTokenKeyURL")]
		NSString BTClientTokenKeyURL { get; }

		// extern NSString *const BTClientTokenKeyMerchantId;
		[Field ("BTClientTokenKeyMerchantId")]
		NSString BTClientTokenKeyMerchantId { get; }

		// extern NSString *const BTClientTokenKeyVersion;
		[Field ("BTClientTokenKeyVersion")]
		NSString BTClientTokenKeyVersion { get; }

		// extern NSString *const BTClientTokenKeyApplePay;
		[Field ("BTClientTokenKeyApplePay")]
		NSString BTClientTokenKeyApplePay { get; }

		// extern NSString *const BTClientTokenKeyStatus;
		[Field ("BTClientTokenKeyStatus")]
		NSString BTClientTokenKeyStatus { get; }

		// extern NSString *const BTClientTokenKeyMerchantAccountId;
		[Field ("BTClientTokenKeyMerchantAccountId")]
		NSString BTClientTokenKeyMerchantAccountId { get; }

		// extern NSString *const BTClientTokenKeyPayPal;
		[Field ("BTClientTokenKeyPayPal")]
		NSString BTClientTokenKeyPayPal { get; }

		// extern NSString *const BTClientTokenKeyPayPalClientId;
		[Field ("BTClientTokenKeyPayPalClientId")]
		NSString BTClientTokenKeyPayPalClientId { get; }

		// extern NSString *const BTClientTokenKeyPayPalDirectBaseUrl;
		[Field ("BTClientTokenKeyPayPalDirectBaseUrl")]
		NSString BTClientTokenKeyPayPalDirectBaseUrl { get; }

		// extern NSString *const BTClientTokenKeyPayPalMerchantName;
		[Field ("BTClientTokenKeyPayPalMerchantName")]
		NSString BTClientTokenKeyPayPalMerchantName { get; }

		// extern NSString *const BTClientTokenKeyPayPalMerchantPrivacyPolicyUrl;
		[Field ("BTClientTokenKeyPayPalMerchantPrivacyPolicyUrl")]
		NSString BTClientTokenKeyPayPalMerchantPrivacyPolicyUrl { get; }

		// extern NSString *const BTClientTokenKeyPayPalMerchantUserAgreementUrl;
		[Field ("BTClientTokenKeyPayPalMerchantUserAgreementUrl")]
		NSString BTClientTokenKeyPayPalMerchantUserAgreementUrl { get; }

		// extern NSString *const BTClientTokenKeyPayPalEnvironment;
		[Field ("BTClientTokenKeyPayPalEnvironment")]
		NSString BTClientTokenKeyPayPalEnvironment { get; }

		// extern NSString *const BTClientTokenKeyPayPalEnabled;
		[Field ("BTClientTokenKeyPayPalEnabled")]
		NSString BTClientTokenKeyPayPalEnabled { get; }

		// extern NSString *const BTClientTokenPayPalEnvironmentCustom;
		[Field ("BTClientTokenPayPalEnvironmentCustom")]
		NSString BTClientTokenPayPalEnvironmentCustom { get; }

		// extern NSString *const BTClientTokenPayPalEnvironmentLive;
		[Field ("BTClientTokenPayPalEnvironmentLive")]
		NSString BTClientTokenPayPalEnvironmentLive { get; }

		// extern NSString *const BTClientTokenPayPalEnvironmentOffline;
		[Field ("BTClientTokenPayPalEnvironmentOffline")]
		NSString BTClientTokenPayPalEnvironmentOffline { get; }

		// extern NSString *const BTClientTokenKeyPayPalDisableAppSwitch;
		[Field ("BTClientTokenKeyPayPalDisableAppSwitch")]
		NSString BTClientTokenKeyPayPalDisableAppSwitch { get; }

		// extern NSString *const BTClientTokenKeyVenmo;
		[Field ("BTClientTokenKeyVenmo")]
		NSString BTClientTokenKeyVenmo { get; }

		// extern NSString *const BTClientTokenPayPalNonLiveDefaultValueMerchantName;
		[Field ("BTClientTokenPayPalNonLiveDefaultValueMerchantName")]
		NSString BTClientTokenPayPalNonLiveDefaultValueMerchantName { get; }

		// extern NSString *const BTClientTokenPayPalNonLiveDefaultValueMerchantPrivacyPolicyUrl;
		[Field ("BTClientTokenPayPalNonLiveDefaultValueMerchantPrivacyPolicyUrl")]
		NSString BTClientTokenPayPalNonLiveDefaultValueMerchantPrivacyPolicyUrl { get; }

		// extern NSString *const BTClientTokenPayPalNonLiveDefaultValueMerchantUserAgreementUrl;
		[Field ("BTClientTokenPayPalNonLiveDefaultValueMerchantUserAgreementUrl")]
		NSString BTClientTokenPayPalNonLiveDefaultValueMerchantUserAgreementUrl { get; }
	}

	// @interface BTClientToken : NSObject <NSCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface BTClientToken : INSCoding, INSCopying
	{
		// @property (readonly, copy, nonatomic) NSString * authorizationFingerprint;
		[Export ("authorizationFingerprint")]
		string AuthorizationFingerprint { get; }

		// @property (readonly, nonatomic, strong) NSURL * clientApiURL;
		[Export ("clientApiURL", ArgumentSemantic.Strong)]
		NSURL ClientApiURL { get; }

		// @property (readonly, nonatomic, strong) NSURL * analyticsURL;
		[Export ("analyticsURL", ArgumentSemantic.Strong)]
		NSURL AnalyticsURL { get; }

		// @property (readonly, nonatomic, strong) NSURL * configURL;
		[Export ("configURL", ArgumentSemantic.Strong)]
		NSURL ConfigURL { get; }

		// @property (readonly, copy, nonatomic) NSString * merchantId;
		[Export ("merchantId")]
		string MerchantId { get; }

		// @property (readonly, copy, nonatomic) NSString * merchantAccountId;
		[Export ("merchantAccountId")]
		string MerchantAccountId { get; }

		// -(BOOL)analyticsEnabled;
		[Export ("analyticsEnabled")]
		[Verify (MethodToProperty)]
		bool AnalyticsEnabled { get; }

		// @property (readonly, nonatomic, strong) NSSet * challenges;
		[Export ("challenges", ArgumentSemantic.Strong)]
		NSSet Challenges { get; }

		// -(NSString *)btPayPal_clientId;
		[Export ("btPayPal_clientId")]
		[Verify (MethodToProperty)]
		string BtPayPal_clientId { get; }

		// -(BOOL)btPayPal_isPayPalEnabled;
		[Export ("btPayPal_isPayPalEnabled")]
		[Verify (MethodToProperty)]
		bool BtPayPal_isPayPalEnabled { get; }

		// -(NSString *)btPayPal_environment;
		[Export ("btPayPal_environment")]
		[Verify (MethodToProperty)]
		string BtPayPal_environment { get; }

		// -(BOOL)btPayPal_isTouchDisabled;
		[Export ("btPayPal_isTouchDisabled")]
		[Verify (MethodToProperty)]
		bool BtPayPal_isTouchDisabled { get; }

		// -(NSString *)btPayPal_merchantName;
		[Export ("btPayPal_merchantName")]
		[Verify (MethodToProperty)]
		string BtPayPal_merchantName { get; }

		// -(NSURL *)btPayPal_merchantUserAgreementURL;
		[Export ("btPayPal_merchantUserAgreementURL")]
		[Verify (MethodToProperty)]
		NSURL BtPayPal_merchantUserAgreementURL { get; }

		// -(NSURL *)btPayPal_privacyPolicyURL;
		[Export ("btPayPal_privacyPolicyURL")]
		[Verify (MethodToProperty)]
		NSURL BtPayPal_privacyPolicyURL { get; }

		// -(NSURL *)btPayPal_directBaseURL;
		[Export ("btPayPal_directBaseURL")]
		[Verify (MethodToProperty)]
		NSURL BtPayPal_directBaseURL { get; }

		// -(NSString *)btVenmo_status;
		[Export ("btVenmo_status")]
		[Verify (MethodToProperty)]
		string BtVenmo_status { get; }

		// @property (readonly, nonatomic, strong) NSDictionary * applePayConfiguration;
		[Export ("applePayConfiguration", ArgumentSemantic.Strong)]
		NSDictionary ApplePayConfiguration { get; }

		// -(BTClientApplePayStatus)applePayStatus;
		[Export ("applePayStatus")]
		[Verify (MethodToProperty)]
		BTClientApplePayStatus ApplePayStatus { get; }

		// -(NSString *)applePayCountryCode;
		[Export ("applePayCountryCode")]
		[Verify (MethodToProperty)]
		string ApplePayCountryCode { get; }

		// -(NSString *)applePayCurrencyCode;
		[Export ("applePayCurrencyCode")]
		[Verify (MethodToProperty)]
		string ApplePayCurrencyCode { get; }

		// -(NSString *)applePayMerchantIdentifier;
		[Export ("applePayMerchantIdentifier")]
		[Verify (MethodToProperty)]
		string ApplePayMerchantIdentifier { get; }

		// -(NSArray *)applePaySupportedNetworks;
		[Export ("applePaySupportedNetworks")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] ApplePaySupportedNetworks { get; }

		// -(instancetype)initWithClientTokenString:(NSString *)JSONString error:(NSError **)error __attribute__((objc_designated_initializer));
		[Export ("initWithClientTokenString:error:")]
		IntPtr Constructor (string JSONString, out NSError error);
	}

	// @interface BTClientTokenBooleanValueTransformer : NSObject <BTValueTransforming>
	[BaseType (typeof(NSObject))]
	interface BTClientTokenBooleanValueTransformer : IBTValueTransforming
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		BTClientTokenBooleanValueTransformer SharedInstance ();
	}

	// @interface BTHTTPResponse : NSObject
	[BaseType (typeof(NSObject))]
	interface BTHTTPResponse
	{
		// @property (readonly, nonatomic, strong) BTAPIResponseParser * object;
		[Export ("object", ArgumentSemantic.Strong)]
		BTAPIResponseParser Object { get; }

		// @property (readonly, nonatomic, strong) NSDictionary * rawObject;
		[Export ("rawObject", ArgumentSemantic.Strong)]
		NSDictionary RawObject { get; }

		// @property (readonly, assign, nonatomic) NSInteger statusCode;
		[Export ("statusCode", ArgumentSemantic.Assign)]
		nint StatusCode { get; }

		// @property (readonly, getter = isSuccess, assign, nonatomic) BOOL success;
		[Export ("success")]
		bool Success { [Bind ("isSuccess")] get; }

		// -(instancetype)initWithStatusCode:(NSInteger)statusCode responseObject:(NSDictionary *)response;
		[Export ("initWithStatusCode:responseObject:")]
		IntPtr Constructor (nint statusCode, NSDictionary response);
	}

	// @interface BTHTTPResponse : NSObject
//	[BaseType (typeof(NSObject))]
//	interface BTHTTPResponse
//	{
//	}

	// typedef void (^BTHTTPCompletionBlock)(BTHTTPResponse *, NSError *);
	delegate void BTHTTPCompletionBlock (BTHTTPResponse arg0, NSError arg1);

	// @interface BTHTTP : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface BTHTTP : INSCopying
	{
		// @property (nonatomic, strong) NSArray * pinnedCertificates;
		[Export ("pinnedCertificates", ArgumentSemantic.Strong)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] PinnedCertificates { get; set; }

		// -(instancetype)initWithBaseURL:(NSURL *)URL;
		[Export ("initWithBaseURL:")]
		IntPtr Constructor (NSURL URL);

		// -(void)setProtocolClasses:(NSArray *)protocolClasses;
		[Export ("setProtocolClasses:")]
		[Verify (StronglyTypedNSArray)]
		void SetProtocolClasses (NSObject[] protocolClasses);

		// -(void)GET:(NSString *)url completion:(BTHTTPCompletionBlock)completionBlock;
		[Export ("GET:completion:")]
		void GET (string url, BTHTTPCompletionBlock completionBlock);

		// -(void)GET:(NSString *)url parameters:(NSDictionary *)parameters completion:(BTHTTPCompletionBlock)completionBlock;
		[Export ("GET:parameters:completion:")]
		void GET (string url, NSDictionary parameters, BTHTTPCompletionBlock completionBlock);

		// -(void)POST:(NSString *)url completion:(BTHTTPCompletionBlock)completionBlock;
		[Export ("POST:completion:")]
		void POST (string url, BTHTTPCompletionBlock completionBlock);

		// -(void)POST:(NSString *)url parameters:(NSDictionary *)parameters completion:(BTHTTPCompletionBlock)completionBlock;
		[Export ("POST:parameters:completion:")]
		void POST (string url, NSDictionary parameters, BTHTTPCompletionBlock completionBlock);

		// -(void)PUT:(NSString *)url completion:(BTHTTPCompletionBlock)completionBlock;
		[Export ("PUT:completion:")]
		void PUT (string url, BTHTTPCompletionBlock completionBlock);

		// -(void)PUT:(NSString *)url parameters:(NSDictionary *)parameters completion:(BTHTTPCompletionBlock)completionBlock;
		[Export ("PUT:parameters:completion:")]
		void PUT (string url, NSDictionary parameters, BTHTTPCompletionBlock completionBlock);

		// -(void)DELETE:(NSString *)url completion:(BTHTTPCompletionBlock)completionBlock;
		[Export ("DELETE:completion:")]
		void DELETE (string url, BTHTTPCompletionBlock completionBlock);

		// -(void)DELETE:(NSString *)url parameters:(NSDictionary *)parameters completion:(BTHTTPCompletionBlock)completionBlock;
		[Export ("DELETE:parameters:completion:")]
		void DELETE (string url, NSDictionary parameters, BTHTTPCompletionBlock completionBlock);
	}

	// @interface BTThreeDSecureLookupResult : NSObject
	[BaseType (typeof(NSObject))]
	interface BTThreeDSecureLookupResult
	{
		// @property (copy, nonatomic) NSString * PAReq;
		[Export ("PAReq")]
		string PAReq { get; set; }

		// @property (copy, nonatomic) NSString * MD;
		[Export ("MD")]
		string MD { get; set; }

		// @property (copy, nonatomic) NSURL * acsURL;
		[Export ("acsURL", ArgumentSemantic.Copy)]
		NSURL AcsURL { get; set; }

		// @property (copy, nonatomic) NSURL * termURL;
		[Export ("termURL", ArgumentSemantic.Copy)]
		NSURL TermURL { get; set; }

		// @property (nonatomic, strong) BTCardPaymentMethod * card;
		[Export ("card", ArgumentSemantic.Strong)]
		BTCardPaymentMethod Card { get; set; }

		// -(BOOL)requiresUserAuthentication;
		[Export ("requiresUserAuthentication")]
		[Verify (MethodToProperty)]
		bool RequiresUserAuthentication { get; }
	}

	// typedef void (^BTClientThreeDSecureLookupSuccessBlock)(BTThreeDSecureLookupResult *);
	delegate void BTClientThreeDSecureLookupSuccessBlock (BTThreeDSecureLookupResult arg0);

	// @interface  (BTClient)
	[Category]
	[BaseType (typeof(BTClient))]
	interface BTClient_
	{
		// @property (readwrite, nonatomic, strong) BTHTTP * clientApiHttp;
		[Export ("clientApiHttp")]
		BTHTTP ClientApiHttp { get; set; }

		// @property (readwrite, nonatomic, strong) BTHTTP * analyticsHttp;
		[Export ("analyticsHttp")]
		BTHTTP AnalyticsHttp { get; set; }

		// @property (nonatomic, strong) BTClientToken * clientToken;
		[Export ("clientToken")]
		BTClientToken ClientToken { get; set; }

		// -(void)lookupNonceForThreeDSecure:(NSString *)nonce transactionAmount:(NSDecimalNumber *)amount success:(BTClientThreeDSecureLookupSuccessBlock)successBlock failure:(BTClientFailureBlock)failureBlock;
		[Export ("lookupNonceForThreeDSecure:transactionAmount:success:failure:")]
		void LookupNonceForThreeDSecure (string nonce, NSDecimalNumber amount, BTClientThreeDSecureLookupSuccessBlock successBlock, BTClientFailureBlock failureBlock);

		// @property (readonly, copy, nonatomic) BTClientMetadata * metadata;
		[Export ("metadata")]
		BTClientMetadata Metadata { get; }

		// -(instancetype)copyWithMetadata:(void (^)(BTClientMutableMetadata *))metadataBlock;
		[Export ("copyWithMetadata:")]
		BTClient CopyWithMetadata (Action<BTClientMutableMetadata> metadataBlock);
	}

	// @protocol DeviceCollectorSDKDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface DeviceCollectorSDKDelegate
	{
		// @optional -(void)onCollectorStart;
		[Export ("onCollectorStart")]
		void OnCollectorStart ();

		// @optional -(void)onCollectorSuccess;
		[Export ("onCollectorSuccess")]
		void OnCollectorSuccess ();

		// @optional -(void)onCollectorError:(int)errorCode withError:(NSError *)error;
		[Export ("onCollectorError:withError:")]
		void OnCollectorError (int errorCode, NSError error);
	}

	// @interface DeviceCollectorSDK : NSObject <UIWebViewDelegate>
	[BaseType (typeof(NSObject))]
	interface DeviceCollectorSDK : IUIWebViewDelegate
	{
		// @property (nonatomic, strong) NSArray * skipList;
		[Export ("skipList", ArgumentSemantic.Strong)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] SkipList { get; set; }

		// -(DeviceCollectorSDK *)initWithDebugOn:(_Bool)debugLogging;
		[Export ("initWithDebugOn:")]
		IntPtr Constructor (bool debugLogging);

		// -(void)setCollectorUrl:(NSString *)url;
		[Export ("setCollectorUrl:")]
		void SetCollectorUrl (string url);

		// -(void)setMerchantId:(NSString *)merc;
		[Export ("setMerchantId:")]
		void SetMerchantId (string merc);

		// -(void)collect:(NSString *)sessionId;
		[Export ("collect:")]
		void Collect (string sessionId);

		// -(void)setDelegate:(id<DeviceCollectorSDKDelegate>)delegate;
		[Export ("setDelegate:")]
		void SetDelegate (DeviceCollectorSDKDelegate @delegate);
	}

	// @protocol BTDataDelegate <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface BTDataDelegate
//	{
//	}

	// @interface BTData : NSObject
	[BaseType (typeof(NSObject))]
	interface BTData
	{
		[Wrap ("WeakDelegate")]
		BTDataDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTDataDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype)initWithClient:(BTClient *)client environment:(BTDataEnvironment)environment __attribute__((objc_designated_initializer));
		[Export ("initWithClient:environment:")]
		IntPtr Constructor (BTClient client, BTDataEnvironment environment);

		// -(NSString *)collectDeviceData;
		[Export ("collectDeviceData")]
		[Verify (MethodToProperty)]
		string CollectDeviceData { get; }

		// -(void)setFraudMerchantId:(NSString *)fraudMerchantId;
		[Export ("setFraudMerchantId:")]
		void SetFraudMerchantId (string fraudMerchantId);

		// -(void)setCollectorUrl:(NSString *)url;
		[Export ("setCollectorUrl:")]
		void SetCollectorUrl (string url);

		// -(instancetype)initWithDebugOn:(BOOL)debugLogging __attribute__((deprecated("Please use initWithClient:environment:")));
		[Export ("initWithDebugOn:")]
		IntPtr Constructor (bool debugLogging);

		// +(instancetype)defaultDataForEnvironment:(BTDataEnvironment)environment delegate:(id<BTDataDelegate>)delegate __attribute__((deprecated("Please use initWithClient:environment:")));
		[Static]
		[Export ("defaultDataForEnvironment:delegate:")]
		BTData DefaultDataForEnvironment (BTDataEnvironment environment, BTDataDelegate @delegate);

		// -(NSString *)collect __attribute__((deprecated("Please use the collectDeviceData method instead")));
		[Export ("collect")]
		[Verify (MethodToProperty)]
		string Collect { get; }

		// -(void)collect:(NSString *)sessionId __attribute__((deprecated("Please use the collectDeviceData method instead")));
//		[Export ("collect:")]
//		void Collect (string sessionId);
//
		// -(void)setKountMerchantId:(NSString *)merc __attribute__((deprecated("Please use setFraudMerchantId instead")));
		[Export ("setKountMerchantId:")]
		void SetKountMerchantId (string merc);
	}

	// @protocol BTDataDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTDataDelegate
	{
		// @optional -(void)btDataDidStartCollectingData:(BTData *)data;
		[Export ("btDataDidStartCollectingData:")]
		void BtDataDidStartCollectingData (BTData data);

		// @optional -(void)btDataDidComplete:(BTData *)data;
		[Export ("btDataDidComplete:")]
		void BtDataDidComplete (BTData data);

		// @optional -(void)btData:(BTData *)data didFailWithErrorCode:(int)errorCode error:(NSError *)error;
		[Export ("btData:didFailWithErrorCode:error:")]
		void BtData (BTData data, int errorCode, NSError error);
	}

	// @interface BTUIVectorArtView : UIView
	[BaseType (typeof(UIView))]
	interface BTUIVectorArtView
	{
		// -(void)drawArt;
		[Export ("drawArt")]
		void DrawArt ();

		// @property (assign, nonatomic) CGSize artDimensions;
		[Export ("artDimensions", ArgumentSemantic.Assign)]
		CGSize ArtDimensions { get; set; }

		// -(UIImage *)imageOfSize:(CGSize)size;
		[Export ("imageOfSize:")]
		UIImage ImageOfSize (CGSize size);
	}

	// @interface BTUI : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUI
	{
		// +(BTUI *)braintreeTheme;
		[Static]
		[Export ("braintreeTheme")]
		[Verify (MethodToProperty)]
		BTUI BraintreeTheme { get; }

		// -(UIColor *)idealGray;
		[Export ("idealGray")]
		[Verify (MethodToProperty)]
		UIColor IdealGray { get; }

		// -(UIColor *)defaultTintColor;
		[Export ("defaultTintColor")]
		[Verify (MethodToProperty)]
		UIColor DefaultTintColor { get; }

		// -(UIColor *)viewBackgroundColor;
		[Export ("viewBackgroundColor")]
		[Verify (MethodToProperty)]
		UIColor ViewBackgroundColor { get; }

		// -(UIColor *)callToActionColor;
		[Export ("callToActionColor")]
		[Verify (MethodToProperty)]
		UIColor CallToActionColor { get; }

		// -(UIColor *)callToActionColorHighlighted;
		[Export ("callToActionColorHighlighted")]
		[Verify (MethodToProperty)]
		UIColor CallToActionColorHighlighted { get; }

		// -(UIColor *)disabledButtonColor;
		[Export ("disabledButtonColor")]
		[Verify (MethodToProperty)]
		UIColor DisabledButtonColor { get; }

		// -(UIColor *)titleColor;
		[Export ("titleColor")]
		[Verify (MethodToProperty)]
		UIColor TitleColor { get; }

		// -(UIColor *)detailColor;
		[Export ("detailColor")]
		[Verify (MethodToProperty)]
		UIColor DetailColor { get; }

		// -(UIColor *)borderColor;
		[Export ("borderColor")]
		[Verify (MethodToProperty)]
		UIColor BorderColor { get; }

		// -(UIColor *)textFieldTextColor;
		[Export ("textFieldTextColor")]
		[Verify (MethodToProperty)]
		UIColor TextFieldTextColor { get; }

		// -(UIColor *)textFieldPlaceholderColor;
		[Export ("textFieldPlaceholderColor")]
		[Verify (MethodToProperty)]
		UIColor TextFieldPlaceholderColor { get; }

		// -(UIColor *)sectionHeaderTextColor;
		[Export ("sectionHeaderTextColor")]
		[Verify (MethodToProperty)]
		UIColor SectionHeaderTextColor { get; }

		// -(UIColor *)textFieldFloatLabelTextColor;
		[Export ("textFieldFloatLabelTextColor")]
		[Verify (MethodToProperty)]
		UIColor TextFieldFloatLabelTextColor { get; }

		// -(UIColor *)cardHintBorderColor;
		[Export ("cardHintBorderColor")]
		[Verify (MethodToProperty)]
		UIColor CardHintBorderColor { get; }

		// -(UIColor *)errorBackgroundColor;
		[Export ("errorBackgroundColor")]
		[Verify (MethodToProperty)]
		UIColor ErrorBackgroundColor { get; }

		// -(UIColor *)errorForegroundColor;
		[Export ("errorForegroundColor")]
		[Verify (MethodToProperty)]
		UIColor ErrorForegroundColor { get; }

		// -(CGFloat)highlightedBrightnessAdjustment;
		[Export ("highlightedBrightnessAdjustment")]
		[Verify (MethodToProperty)]
		nfloat HighlightedBrightnessAdjustment { get; }

		// -(UIColor *)payBlue;
		[Export ("payBlue")]
		[Verify (MethodToProperty)]
		UIColor PayBlue { get; }

		// -(UIColor *)palBlue;
		[Export ("palBlue")]
		[Verify (MethodToProperty)]
		UIColor PalBlue { get; }

		// -(UIColor *)payPalButtonBlue;
		[Export ("payPalButtonBlue")]
		[Verify (MethodToProperty)]
		UIColor PayPalButtonBlue { get; }

		// -(UIColor *)payPalButtonActiveBlue;
		[Export ("payPalButtonActiveBlue")]
		[Verify (MethodToProperty)]
		UIColor PayPalButtonActiveBlue { get; }

		// -(UIColor *)venmoPrimaryBlue;
		[Export ("venmoPrimaryBlue")]
		[Verify (MethodToProperty)]
		UIColor VenmoPrimaryBlue { get; }

		// -(UIFont *)controlFont;
		[Export ("controlFont")]
		[Verify (MethodToProperty)]
		UIFont ControlFont { get; }

		// -(UIFont *)controlTitleFont;
		[Export ("controlTitleFont")]
		[Verify (MethodToProperty)]
		UIFont ControlTitleFont { get; }

		// -(UIFont *)controlDetailFont;
		[Export ("controlDetailFont")]
		[Verify (MethodToProperty)]
		UIFont ControlDetailFont { get; }

		// -(UIFont *)textFieldFont;
		[Export ("textFieldFont")]
		[Verify (MethodToProperty)]
		UIFont TextFieldFont { get; }

		// -(UIFont *)textFieldFloatLabelFont;
		[Export ("textFieldFloatLabelFont")]
		[Verify (MethodToProperty)]
		UIFont TextFieldFloatLabelFont { get; }

		// -(UIFont *)sectionHeaderFont;
		[Export ("sectionHeaderFont")]
		[Verify (MethodToProperty)]
		UIFont SectionHeaderFont { get; }

		// -(NSDictionary *)textFieldTextAttributes;
		[Export ("textFieldTextAttributes")]
		[Verify (MethodToProperty)]
		NSDictionary TextFieldTextAttributes { get; }

		// -(NSDictionary *)textFieldPlaceholderAttributes;
		[Export ("textFieldPlaceholderAttributes")]
		[Verify (MethodToProperty)]
		NSDictionary TextFieldPlaceholderAttributes { get; }

		// -(CGFloat)borderWidth;
		[Export ("borderWidth")]
		[Verify (MethodToProperty)]
		nfloat BorderWidth { get; }

		// -(CGFloat)cornerRadius;
		[Export ("cornerRadius")]
		[Verify (MethodToProperty)]
		nfloat CornerRadius { get; }

		// -(CGFloat)formattedEntryKerning;
		[Export ("formattedEntryKerning")]
		[Verify (MethodToProperty)]
		nfloat FormattedEntryKerning { get; }

		// -(CGFloat)horizontalMargin;
		[Export ("horizontalMargin")]
		[Verify (MethodToProperty)]
		nfloat HorizontalMargin { get; }

		// -(CGFloat)paymentButtonMinHeight;
		[Export ("paymentButtonMinHeight")]
		[Verify (MethodToProperty)]
		nfloat PaymentButtonMinHeight { get; }

		// -(CGFloat)paymentButtonMaxHeight;
		[Export ("paymentButtonMaxHeight")]
		[Verify (MethodToProperty)]
		nfloat PaymentButtonMaxHeight { get; }

		// -(CGFloat)paymentButtonWordMarkHeight;
		[Export ("paymentButtonWordMarkHeight")]
		[Verify (MethodToProperty)]
		nfloat PaymentButtonWordMarkHeight { get; }

		// -(CGFloat)quickTransitionDuration;
		[Export ("quickTransitionDuration")]
		[Verify (MethodToProperty)]
		nfloat QuickTransitionDuration { get; }

		// -(CGFloat)transitionDuration;
		[Export ("transitionDuration")]
		[Verify (MethodToProperty)]
		nfloat TransitionDuration { get; }

		// -(CGFloat)minimumVisibilityTime;
		[Export ("minimumVisibilityTime")]
		[Verify (MethodToProperty)]
		nfloat MinimumVisibilityTime { get; }

		// -(BTUIVectorArtView *)vectorArtViewForPaymentMethodType:(BTUIPaymentMethodType)type;
		[Export ("vectorArtViewForPaymentMethodType:")]
		BTUIVectorArtView VectorArtViewForPaymentMethodType (BTUIPaymentMethodType type);

		// +(UIActivityIndicatorViewStyle)activityIndicatorViewStyleForBarTintColor:(UIColor *)color;
		[Static]
		[Export ("activityIndicatorViewStyleForBarTintColor:")]
		UIActivityIndicatorViewStyle ActivityIndicatorViewStyleForBarTintColor (UIColor color);
	}

	// @interface BTUIThemedView : UIView
	[BaseType (typeof(UIView))]
	interface BTUIThemedView
	{
		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @interface BTUICTAControl : UIControl
	[BaseType (typeof(UIControl))]
	interface BTUICTAControl
	{
		// @property (copy, nonatomic) NSString * amount;
		[Export ("amount")]
		string Amount { get; set; }

		// @property (copy, nonatomic) NSString * callToAction;
		[Export ("callToAction")]
		string CallToAction { get; set; }

		// -(void)showLoadingState:(BOOL)loadingState;
		[Export ("showLoadingState:")]
		void ShowLoadingState (bool loadingState);

		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @interface BTUISummaryView : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTUISummaryView
	{
		// @property (copy, nonatomic) NSString * slug;
		[Export ("slug")]
		string Slug { get; set; }

		// @property (copy, nonatomic) NSString * summary;
		[Export ("summary")]
		string Summary { get; set; }

		// @property (copy, nonatomic) NSString * amount;
		[Export ("amount")]
		string Amount { get; set; }
	}

	// @protocol BTUICardFormViewDelegate <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface BTUICardFormViewDelegate
//	{
//	}
//
	// @interface BTUICardFormView : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTUICardFormView
	{
		[Wrap ("WeakDelegate")]
		BTUICardFormViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTUICardFormViewDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, assign, nonatomic) BOOL valid;
		[Export ("valid")]
		bool Valid { get; }

		// @property (readonly, copy, nonatomic) NSString * number;
		[Export ("number")]
		string Number { get; }

		// @property (readonly, copy, nonatomic) NSString * cvv;
		[Export ("cvv")]
		string Cvv { get; }

		// @property (readonly, copy, nonatomic) NSString * expirationMonth;
		[Export ("expirationMonth")]
		string ExpirationMonth { get; }

		// @property (readonly, copy, nonatomic) NSString * expirationYear;
		[Export ("expirationYear")]
		string ExpirationYear { get; }

		// @property (readonly, copy, nonatomic) NSString * postalCode;
		[Export ("postalCode")]
		string PostalCode { get; }

		// -(void)showTopLevelError:(NSString *)message;
		[Export ("showTopLevelError:")]
		void ShowTopLevelError (string message);

		// -(void)showErrorForField:(BTUICardFormField)field;
		[Export ("showErrorForField:")]
		void ShowErrorForField (BTUICardFormField field);

		// @property (assign, nonatomic) BOOL alphaNumericPostalCode;
		[Export ("alphaNumericPostalCode")]
		bool AlphaNumericPostalCode { get; set; }

		// @property (assign, nonatomic) BTUICardFormOptionalFields optionalFields;
		[Export ("optionalFields", ArgumentSemantic.Assign)]
		BTUICardFormOptionalFields OptionalFields { get; set; }

		// @property (assign, nonatomic) BOOL vibrate;
		[Export ("vibrate")]
		bool Vibrate { get; set; }
	}

	// @protocol BTUICardFormViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTUICardFormViewDelegate
	{
		// @required -(void)cardFormViewDidChange:(BTUICardFormView *)cardFormView;
		[Abstract]
		[Export ("cardFormViewDidChange:")]
		void CardFormViewDidChange (BTUICardFormView cardFormView);
	}

	// @interface BTUIPaymentMethodView : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTUIPaymentMethodView
	{
		// @property (assign, nonatomic) BTUIPaymentMethodType type;
		[Export ("type", ArgumentSemantic.Assign)]
		BTUIPaymentMethodType Type { get; set; }

		// @property (copy, nonatomic) NSString * detailDescription;
		[Export ("detailDescription")]
		string DetailDescription { get; set; }

		// @property (getter = isProcessing, assign, nonatomic) BOOL processing;
		[Export ("processing")]
		bool Processing { [Bind ("isProcessing")] get; set; }
	}

	// @interface BTUI : NSObject
//	[BaseType (typeof(NSObject))]
//	interface BTUI
//	{
//	}

	// @interface BTUIVenmoButton : UIControl
	[BaseType (typeof(UIControl))]
	interface BTUIVenmoButton
	{
		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @interface BTUI : NSObject
//	[BaseType (typeof(NSObject))]
//	interface BTUI
//	{
//	}

	// @interface BTUIPayPalButton : UIControl
	[BaseType (typeof(UIControl))]
	interface BTUIPayPalButton
	{
		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const BTBraintreePayPalErrorDomain;
		[Field ("BTBraintreePayPalErrorDomain")]
		NSString BTBraintreePayPalErrorDomain { get; }

		// extern enum BTPayPalErrorCode BTPayPalErrorCode;
		[Field ("BTPayPalErrorCode")]
		BTPayPalErrorCode BTPayPalErrorCode { get; }
	}

	// @interface BTLogger : NSObject
	[BaseType (typeof(NSObject))]
	interface BTLogger
	{
		// +(instancetype)sharedLogger;
		[Static]
		[Export ("sharedLogger")]
		BTLogger SharedLogger ();

		// @property (assign, nonatomic) BTLogLevel level;
		[Export ("level", ArgumentSemantic.Assign)]
		BTLogLevel Level { get; set; }

		// @property (copy, nonatomic) void (^)(BTLogLevel, NSString *) logBlock;
		[Export ("logBlock", ArgumentSemantic.Copy)]
		Action<BTLogLevel, NSString> LogBlock { get; set; }
	}

	// @protocol BTPayPalButtonDelegate <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface BTPayPalButtonDelegate
//	{
//	}

	// @protocol BTPayPalButtonViewControllerPresenterDelegate <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface BTPayPalButtonViewControllerPresenterDelegate
//	{
//	}

	// @interface BTPayPalButton : UIControl
	[BaseType (typeof(UIControl))]
	interface BTPayPalButton
	{
		// -(id)initWithFrame:(CGRect)frame __attribute__((deprecated("Please use BTUIPayPalButton or BTPaymentButton. BTPayPalButton is deprecated.")));
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// -(id)initWithCoder:(NSCoder *)aDecoder __attribute__((deprecated("Please use BTUIPayPalButton or BTPaymentButton. BTPayPalButton is deprecated.")));
		[Export ("initWithCoder:")]
		IntPtr Constructor (NSCoder aDecoder);

		[Wrap ("WeakDelegate")]
		BTPayPalButtonDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTPayPalButtonDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakPresentationDelegate")]
		BTPayPalButtonViewControllerPresenterDelegate PresentationDelegate { get; set; }

		// @property (nonatomic, weak) id<BTPayPalButtonViewControllerPresenterDelegate> presentationDelegate;
		[NullAllowed, Export ("presentationDelegate", ArgumentSemantic.Weak)]
		NSObject WeakPresentationDelegate { get; set; }

		// @property (nonatomic, strong) BTClient * client;
		[Export ("client", ArgumentSemantic.Strong)]
		BTClient Client { get; set; }

		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @protocol BTPayPalButtonDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTPayPalButtonDelegate
	{
		// @required -(void)payPalButton:(BTPayPalButton *)button didCreatePayPalPaymentMethod:(BTPayPalPaymentMethod *)paymentMethod;
		[Abstract]
		[Export ("payPalButton:didCreatePayPalPaymentMethod:")]
		void PayPalButton (BTPayPalButton button, BTPayPalPaymentMethod paymentMethod);

		// @required -(void)payPalButton:(BTPayPalButton *)button didFailWithError:(NSError *)error;
		[Abstract]
		[Export ("payPalButton:didFailWithError:")]
		void PayPalButton (BTPayPalButton button, NSError error);

		// @optional -(void)payPalButtonWillCreatePayPalPaymentMethod:(BTPayPalButton *)button;
		[Export ("payPalButtonWillCreatePayPalPaymentMethod:")]
		void PayPalButtonWillCreatePayPalPaymentMethod (BTPayPalButton button);

		// @optional -(void)payPalButtonDidCancel:(BTPayPalButton *)button;
		[Export ("payPalButtonDidCancel:")]
		void PayPalButtonDidCancel (BTPayPalButton button);
	}

	// @protocol BTPayPalButtonViewControllerPresenterDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTPayPalButtonViewControllerPresenterDelegate
	{
		// @required -(void)payPalButton:(BTPayPalButton *)button requestsPresentationOfViewController:(UIViewController *)viewController;
		[Abstract]
		[Export ("payPalButton:requestsPresentationOfViewController:")]
		void RequestsPresentationOfViewController (BTPayPalButton button, UIViewController viewController);

		// @required -(void)payPalButton:(BTPayPalButton *)button requestsDismissalOfViewController:(UIViewController *)viewController;
		[Abstract]
		[Export ("payPalButton:requestsDismissalOfViewController:")]
		void RequestsDismissalOfViewController (BTPayPalButton button, UIViewController viewController);
	}

	// @protocol BTPayPalViewControllerDelegate <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface BTPayPalViewControllerDelegate
//	{
//	}

	// @interface BTPayPalViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface BTPayPalViewController
	{
		[Wrap ("WeakDelegate")]
		BTPayPalViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTPayPalViewControllerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) BTClient * client;
		[Export ("client", ArgumentSemantic.Strong)]
		BTClient Client { get; set; }

		// -(instancetype)initWithClient:(BTClient *)client;
		[Export ("initWithClient:")]
		IntPtr Constructor (BTClient client);

		// @property (readwrite, nonatomic, strong) PayPalProfileSharingViewController * payPalProfileSharingViewController;
		[Export ("payPalProfileSharingViewController", ArgumentSemantic.Strong)]
		PayPalProfileSharingViewController PayPalProfileSharingViewController { get; set; }
	}

	// @protocol BTPayPalViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTPayPalViewControllerDelegate
	{
		// @optional -(void)payPalViewControllerWillCreatePayPalPaymentMethod:(BTPayPalViewController *)viewController;
		[Export ("payPalViewControllerWillCreatePayPalPaymentMethod:")]
		void PayPalViewControllerWillCreatePayPalPaymentMethod (BTPayPalViewController viewController);

		// @optional -(void)payPalViewController:(BTPayPalViewController *)viewController didCreatePayPalPaymentMethod:(BTPayPalPaymentMethod *)payPalPaymentMethod;
		[Export ("payPalViewController:didCreatePayPalPaymentMethod:")]
		void PayPalViewController (BTPayPalViewController viewController, BTPayPalPaymentMethod payPalPaymentMethod);

		// @optional -(void)payPalViewController:(BTPayPalViewController *)viewController didFailWithError:(NSError *)error;
		[Export ("payPalViewController:didFailWithError:")]
		void PayPalViewController (BTPayPalViewController viewController, NSError error);

		// @optional -(void)payPalViewControllerDidCancel:(BTPayPalViewController *)viewController;
		[Export ("payPalViewControllerDidCancel:")]
		void PayPalViewControllerDidCancel (BTPayPalViewController viewController);
	}

	// @interface BTClient : NSObject <NSCoding, NSCopying>
//	[BaseType (typeof(NSObject))]
//	interface BTClient : INSCoding, INSCopying
//	{
//	}

	// @interface BTPaymentMethod : NSObject
//	[BaseType (typeof(NSObject))]
//	interface BTPaymentMethod
//	{
//	}

	// @protocol BTPaymentMethodCreationDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTPaymentMethodCreationDelegate
	{
	}

	// @interface BTPaymentButton : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTPaymentButton
	{
		// -(instancetype)initWithPaymentProviderTypes:(NSOrderedSet *)paymentAuthorizationTypes;
		[Export ("initWithPaymentProviderTypes:")]
		IntPtr Constructor (NSOrderedSet paymentAuthorizationTypes);

		// -(id)initWithFrame:(CGRect)frame;
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// -(id)initWithCoder:(NSCoder *)aDecoder;
		[Export ("initWithCoder:")]
		IntPtr Constructor (NSCoder aDecoder);

		// @property (nonatomic, strong) NSOrderedSet * enabledPaymentProviderTypes;
		[Export ("enabledPaymentProviderTypes", ArgumentSemantic.Strong)]
		NSOrderedSet EnabledPaymentProviderTypes { get; set; }

		// @property (nonatomic, strong) BTClient * client;
		[Export ("client", ArgumentSemantic.Strong)]
		BTClient Client { get; set; }

		[Wrap ("WeakDelegate")]
		BTPaymentMethodCreationDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTPaymentMethodCreationDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

	// @interface BTDropInContentView : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTDropInContentView
	{
		// @property (nonatomic, strong) BTUISummaryView * summaryView;
		[Export ("summaryView", ArgumentSemantic.Strong)]
		BTUISummaryView SummaryView { get; set; }

		// @property (nonatomic, strong) BTUICTAControl * ctaControl;
		[Export ("ctaControl", ArgumentSemantic.Strong)]
		BTUICTAControl CtaControl { get; set; }

		// @property (nonatomic, strong) BTPaymentButton * paymentButton;
		[Export ("paymentButton", ArgumentSemantic.Strong)]
		BTPaymentButton PaymentButton { get; set; }

		// @property (nonatomic, strong) UILabel * cardFormSectionHeader;
		[Export ("cardFormSectionHeader", ArgumentSemantic.Strong)]
		UILabel CardFormSectionHeader { get; set; }

		// @property (nonatomic, strong) BTUICardFormView * cardForm;
		[Export ("cardForm", ArgumentSemantic.Strong)]
		BTUICardFormView CardForm { get; set; }

		// @property (nonatomic, strong) BTUIPaymentMethodView * selectedPaymentMethodView;
		[Export ("selectedPaymentMethodView", ArgumentSemantic.Strong)]
		BTUIPaymentMethodView SelectedPaymentMethodView { get; set; }

		// @property (nonatomic, strong) UIButton * changeSelectedPaymentMethodButton;
		[Export ("changeSelectedPaymentMethodButton", ArgumentSemantic.Strong)]
		UIButton ChangeSelectedPaymentMethodButton { get; set; }

		// @property (assign, nonatomic) BOOL hideCTA;
		[Export ("hideCTA")]
		bool HideCTA { get; set; }

		// @property (assign, nonatomic) BOOL hideSummary;
		[Export ("hideSummary")]
		bool HideSummary { get; set; }

		// @property (assign, nonatomic) BTDropInContentViewStateType state;
		[Export ("state", ArgumentSemantic.Assign)]
		BTDropInContentViewStateType State { get; set; }

		// @property (assign, nonatomic) BOOL hidePayPal;
		[Export ("hidePayPal")]
		bool HidePayPal { get; set; }

		// -(void)setState:(BTDropInContentViewStateType)newState animate:(BOOL)animate;
		[Export ("setState:animate:")]
		void SetState (BTDropInContentViewStateType newState, bool animate);
	}

	// @interface BTDropInErrorAlert : NSObject
	[BaseType (typeof(NSObject))]
	interface BTDropInErrorAlert
	{
		// @property (copy, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; set; }

		// @property (copy, nonatomic) NSString * message;
		[Export ("message")]
		string Message { get; set; }

		// -(instancetype)initWithCancel:(void (^)(void))cancelBlock retry:(void (^)(void))retryBlock;
		[Export ("initWithCancel:retry:")]
		IntPtr Constructor (Action cancelBlock, Action retryBlock);

		// -(void)show;
		[Export ("show")]
		void Show ();
	}

	// @interface BTDropInErrorState : NSObject
	[BaseType (typeof(NSObject))]
	interface BTDropInErrorState
	{
		// -(instancetype)initWithError:(NSError *)error;
		[Export ("initWithError:")]
		IntPtr Constructor (NSError error);

		// @property (readonly, copy, nonatomic) NSString * errorTitle;
		[Export ("errorTitle")]
		string ErrorTitle { get; }

		// @property (readonly, nonatomic, strong) NSSet * highlightedFields;
		[Export ("highlightedFields", ArgumentSemantic.Strong)]
		NSSet HighlightedFields { get; }
	}

	// @interface BTDropInLocalizedString : NSObject
	[BaseType (typeof(NSObject))]
	interface BTDropInLocalizedString
	{
		// +(NSString *)DROP_IN_CHANGE_PAYMENT_METHOD_BUTTON_TEXT;
		[Static]
		[Export ("DROP_IN_CHANGE_PAYMENT_METHOD_BUTTON_TEXT")]
		[Verify (MethodToProperty)]
		string DROP_IN_CHANGE_PAYMENT_METHOD_BUTTON_TEXT { get; }

		// +(NSString *)ERROR_ALERT_OK_BUTTON_TEXT;
		[Static]
		[Export ("ERROR_ALERT_OK_BUTTON_TEXT")]
		[Verify (MethodToProperty)]
		string ERROR_ALERT_OK_BUTTON_TEXT { get; }

		// +(NSString *)ERROR_ALERT_CANCEL_BUTTON_TEXT;
		[Static]
		[Export ("ERROR_ALERT_CANCEL_BUTTON_TEXT")]
		[Verify (MethodToProperty)]
		string ERROR_ALERT_CANCEL_BUTTON_TEXT { get; }

		// +(NSString *)ERROR_ALERT_TRY_AGAIN_BUTTON_TEXT;
		[Static]
		[Export ("ERROR_ALERT_TRY_AGAIN_BUTTON_TEXT")]
		[Verify (MethodToProperty)]
		string ERROR_ALERT_TRY_AGAIN_BUTTON_TEXT { get; }

		// +(NSString *)ERROR_ALERT_CONNECTION_ERROR;
		[Static]
		[Export ("ERROR_ALERT_CONNECTION_ERROR")]
		[Verify (MethodToProperty)]
		string ERROR_ALERT_CONNECTION_ERROR { get; }

		// +(NSString *)DEFAULT_CALL_TO_ACTION;
		[Static]
		[Export ("DEFAULT_CALL_TO_ACTION")]
		[Verify (MethodToProperty)]
		string DEFAULT_CALL_TO_ACTION { get; }

		// +(NSString *)CARD_FORM_SECTION_HEADER;
		[Static]
		[Export ("CARD_FORM_SECTION_HEADER")]
		[Verify (MethodToProperty)]
		string CARD_FORM_SECTION_HEADER { get; }

		// +(NSString *)SELECT_PAYMENT_METHOD_TITLE;
		[Static]
		[Export ("SELECT_PAYMENT_METHOD_TITLE")]
		[Verify (MethodToProperty)]
		string SELECT_PAYMENT_METHOD_TITLE { get; }

		// +(NSString *)ERROR_SAVING_CARD_ALERT_TITLE;
		[Static]
		[Export ("ERROR_SAVING_CARD_ALERT_TITLE")]
		[Verify (MethodToProperty)]
		string ERROR_SAVING_CARD_ALERT_TITLE { get; }

		// +(NSString *)ERROR_SAVING_CARD_MESSAGE;
		[Static]
		[Export ("ERROR_SAVING_CARD_MESSAGE")]
		[Verify (MethodToProperty)]
		string ERROR_SAVING_CARD_MESSAGE { get; }

		// +(NSString *)ERROR_SAVING_PAYMENT_METHOD_ALERT_TITLE;
		[Static]
		[Export ("ERROR_SAVING_PAYMENT_METHOD_ALERT_TITLE")]
		[Verify (MethodToProperty)]
		string ERROR_SAVING_PAYMENT_METHOD_ALERT_TITLE { get; }

		// +(NSString *)ERROR_SAVING_PAYPAL_ACCOUNT_ALERT_MESSAGE;
		[Static]
		[Export ("ERROR_SAVING_PAYPAL_ACCOUNT_ALERT_MESSAGE")]
		[Verify (MethodToProperty)]
		string ERROR_SAVING_PAYPAL_ACCOUNT_ALERT_MESSAGE { get; }

		// +(NSString *)ADD_PAYMENT_METHOD_VIEW_CONTROLLER_TITLE;
		[Static]
		[Export ("ADD_PAYMENT_METHOD_VIEW_CONTROLLER_TITLE")]
		[Verify (MethodToProperty)]
		string ADD_PAYMENT_METHOD_VIEW_CONTROLLER_TITLE { get; }
	}

	// @protocol BTDropInSelectPaymentMethodViewControllerDelegate
//	[Protocol, Model]
//	interface BTDropInSelectPaymentMethodViewControllerDelegate
//	{
//	}

	// @interface BTDropInSelectPaymentMethodViewController : UITableViewController
	[BaseType (typeof(UITableViewController))]
	interface BTDropInSelectPaymentMethodViewController
	{
		// @property (nonatomic, strong) BTClient * client;
		[Export ("client", ArgumentSemantic.Strong)]
		BTClient Client { get; set; }

		[Wrap ("WeakDelegate")]
		BTDropInSelectPaymentMethodViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTDropInSelectPaymentMethodViewControllerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) NSArray * paymentMethods;
		[Export ("paymentMethods", ArgumentSemantic.Strong)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] PaymentMethods { get; set; }

		// @property (assign, nonatomic) NSInteger selectedPaymentMethodIndex;
		[Export ("selectedPaymentMethodIndex", ArgumentSemantic.Assign)]
		nint SelectedPaymentMethodIndex { get; set; }

		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @protocol BTDropInSelectPaymentMethodViewControllerDelegate
	[Protocol, Model]
	interface BTDropInSelectPaymentMethodViewControllerDelegate
	{
		// @required -(void)selectPaymentMethodViewController:(BTDropInSelectPaymentMethodViewController *)viewController didSelectPaymentMethodAtIndex:(NSUInteger)index;
		[Abstract]
		[Export ("selectPaymentMethodViewController:didSelectPaymentMethodAtIndex:")]
		void SelectPaymentMethodViewController (BTDropInSelectPaymentMethodViewController viewController, nuint index);

		// @required -(void)selectPaymentMethodViewControllerDidRequestNew:(BTDropInSelectPaymentMethodViewController *)viewController;
		[Abstract]
		[Export ("selectPaymentMethodViewControllerDidRequestNew:")]
		void SelectPaymentMethodViewControllerDidRequestNew (BTDropInSelectPaymentMethodViewController viewController);
	}

	// @interface BTDropInUtil : NSObject
	[BaseType (typeof(NSObject))]
	interface BTDropInUtil
	{
		// +(BTUIPaymentMethodType)uiForCardType:(BTCardType)cardType;
		[Static]
		[Export ("uiForCardType:")]
		BTUIPaymentMethodType UiForCardType (BTCardType cardType);
	}

	// @interface BTUI : NSObject
//	[BaseType (typeof(NSObject))]
//	interface BTUI
//	{
//	}

	// @protocol BTDropInViewControllerDelegate <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface BTDropInViewControllerDelegate
//	{
//	}

	// @interface BTDropInViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface BTDropInViewController
	{
		// -(instancetype)initWithClient:(BTClient *)client;
		[Export ("initWithClient:")]
		IntPtr Constructor (BTClient client);

		// @property (nonatomic, strong) BTClient * client;
		[Export ("client", ArgumentSemantic.Strong)]
		BTClient Client { get; set; }

		// @property (nonatomic, strong) NSArray * paymentMethods;
		[Export ("paymentMethods", ArgumentSemantic.Strong)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] PaymentMethods { get; set; }

		[Wrap ("WeakDelegate")]
		BTDropInViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTDropInViewControllerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }

		// @property (copy, nonatomic) NSString * summaryTitle;
		[Export ("summaryTitle")]
		string SummaryTitle { get; set; }

		// @property (copy, nonatomic) NSString * summaryDescription;
		[Export ("summaryDescription")]
		string SummaryDescription { get; set; }

		// @property (copy, nonatomic) NSString * displayAmount;
		[Export ("displayAmount")]
		string DisplayAmount { get; set; }

		// @property (copy, nonatomic) NSString * callToActionText;
		[Export ("callToActionText")]
		string CallToActionText { get; set; }

		// @property (assign, nonatomic) BOOL shouldHideCallToAction;
		[Export ("shouldHideCallToAction")]
		bool ShouldHideCallToAction { get; set; }

		// -(void)fetchPaymentMethods;
		[Export ("fetchPaymentMethods")]
		void FetchPaymentMethods ();
	}

	// @protocol BTDropInViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTDropInViewControllerDelegate
	{
		// @required -(void)dropInViewController:(BTDropInViewController *)viewController didSucceedWithPaymentMethod:(BTPaymentMethod *)paymentMethod;
		[Abstract]
		[Export ("dropInViewController:didSucceedWithPaymentMethod:")]
		void DropInViewController (BTDropInViewController viewController, BTPaymentMethod paymentMethod);

		// @required -(void)dropInViewControllerDidCancel:(BTDropInViewController *)viewController;
		[Abstract]
		[Export ("dropInViewControllerDidCancel:")]
		void DropInViewControllerDidCancel (BTDropInViewController viewController);

		// @optional -(void)dropInViewControllerWillComplete:(BTDropInViewController *)viewController;
		[Export ("dropInViewControllerWillComplete:")]
		void DropInViewControllerWillComplete (BTDropInViewController viewController);
	}

	// @interface BTKeychain : NSObject
	[BaseType (typeof(NSObject))]
	interface BTKeychain
	{
		// +(BOOL)setString:(NSString *)string forKey:(NSString *)key;
		[Static]
		[Export ("setString:forKey:")]
		bool SetString (string @string, string key);

		// +(NSString *)stringForKey:(NSString *)key;
		[Static]
		[Export ("stringForKey:")]
		string StringForKey (string key);

		// +(BOOL)setData:(NSData *)data forKey:(NSString *)key;
		[Static]
		[Export ("setData:forKey:")]
		bool SetData (NSData data, string key);

		// +(NSData *)dataForKey:(NSString *)key;
		[Static]
		[Export ("dataForKey:")]
		NSData DataForKey (string key);
	}

	// @interface  (BTLogger)
	[Category]
	[BaseType (typeof(BTLogger))]
	interface BTLogger_
	{
		// -(void)log:(NSString *)format, ...;
		[Internal]
		[Export ("log:", IsVariadic = true)]
		void Log (string format, IntPtr varArgs);

		// -(void)critical:(NSString *)format, ...;
		[Internal]
		[Export ("critical:", IsVariadic = true)]
		void Critical (string format, IntPtr varArgs);

		// -(void)error:(NSString *)format, ...;
		[Internal]
		[Export ("error:", IsVariadic = true)]
		void Error (string format, IntPtr varArgs);

		// -(void)warning:(NSString *)format, ...;
		[Internal]
		[Export ("warning:", IsVariadic = true)]
		void Warning (string format, IntPtr varArgs);

		// -(void)info:(NSString *)format, ...;
		[Internal]
		[Export ("info:", IsVariadic = true)]
		void Info (string format, IntPtr varArgs);

		// -(void)debug:(NSString *)format, ...;
		[Internal]
		[Export ("debug:", IsVariadic = true)]
		void Debug (string format, IntPtr varArgs);

		// @property (copy, nonatomic) void (^)(BTLogLevel, NSString *) logBlock;
		[Export ("logBlock")]
		Action<BTLogLevel, NSString> LogBlock { get; set; }
	}

	// @interface  (BTPaymentMethod)
	[Category]
	[BaseType (typeof(BTPaymentMethod))]
	interface BTPaymentMethod_
	{
		// @property (getter = isLocked, assign, readwrite, nonatomic) BOOL locked;
		[Export ("locked")]
		bool Locked { [Bind ("isLocked")] get; set; }

		// @property (readwrite, copy, nonatomic) NSString * nonce;
		[Export ("nonce")]
		string Nonce { get; set; }

		// @property (readwrite, nonatomic, strong) NSSet * challengeQuestions;
		[Export ("challengeQuestions")]
		NSSet ChallengeQuestions { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * description;
		[Export ("description")]
		string Description { get; set; }
	}

	// @interface BTMutablePaymentMethod : BTPaymentMethod
	[BaseType (typeof(BTPaymentMethod))]
	interface BTMutablePaymentMethod
	{
	}

	// @interface BTMutableCardPaymentMethod : BTCardPaymentMethod
	[BaseType (typeof(BTCardPaymentMethod))]
	interface BTMutableCardPaymentMethod
	{
	}

	// @interface  (BTPayPalPaymentMethod)
	[Category]
	[BaseType (typeof(BTPayPalPaymentMethod))]
	interface BTPayPalPaymentMethod_
	{
		// @property (readwrite, copy, nonatomic) NSString * email;
		[Export ("email")]
		string Email { get; set; }
	}

	// @interface BTMutablePayPalPaymentMethod : BTPayPalPaymentMethod
	[BaseType (typeof(BTPayPalPaymentMethod))]
	interface BTMutablePayPalPaymentMethod
	{
	}

	// @interface BTPaymentMethod : NSObject
//	[BaseType (typeof(NSObject))]
////	interface BTPaymentMethod
//	{
//	}

	// @interface BTOfflineClientBackend : NSObject
	[BaseType (typeof(NSObject))]
	interface BTOfflineClientBackend
	{
		// -(NSArray *)allPaymentMethods;
		[Export ("allPaymentMethods")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] AllPaymentMethods { get; }

		// -(void)addPaymentMethod:(BTPaymentMethod *)card;
		[Export ("addPaymentMethod:")]
		void AddPaymentMethod (BTPaymentMethod card);
	}

	// @interface BTOfflineClientBackend : NSObject
//	[BaseType (typeof(NSObject))]
//	interface BTOfflineClientBackend
//	{
//	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const BTOfflineModeClientApiBaseURL;
		[Field ("BTOfflineModeClientApiBaseURL")]
		NSString BTOfflineModeClientApiBaseURL { get; }
	}

	// @interface BTOfflineModeURLProtocol : NSURLProtocol
	[BaseType (typeof(NSURLProtocol))]
	interface BTOfflineModeURLProtocol
	{
		// +(NSURL *)clientApiBaseURL;
		[Static]
		[Export ("clientApiBaseURL")]
		[Verify (MethodToProperty)]
		NSURL ClientApiBaseURL { get; }

		// +(BTOfflineClientBackend *)backend;
		// +(void)setBackend:(BTOfflineClientBackend *)backend;
		[Static]
		[Export ("backend")]
		[Verify (MethodToProperty)]
		BTOfflineClientBackend Backend { get; set; }
	}

	// @interface BTPayPalAppSwitchHandler : NSObject <BTAppSwitching>
	[BaseType (typeof(NSObject))]
	interface BTPayPalAppSwitchHandler : IBTAppSwitching
	{
		// +(instancetype)sharedHandler;
		[Static]
		[Export ("sharedHandler")]
		BTPayPalAppSwitchHandler SharedHandler ();

		// @property (readwrite, nonatomic, strong) BTClient * client;
		[Export ("client", ArgumentSemantic.Strong)]
		BTClient Client { get; set; }
	}

	// @interface  (BTPayPalAppSwitchHandler)
	[Category]
	[BaseType (typeof(BTPayPalAppSwitchHandler))]
	interface BTPayPalAppSwitchHandler_
	{
		// @property (readwrite, nonatomic, strong) BTClient * client;
		[Export ("client")]
		BTClient Client { get; set; }
	}

	// @interface BTPayPalHorizontalSignatureWhiteView : BTUIVectorArtView
//	[BaseType (typeof(BTUIVectorArtView))]
//	interface BTPayPalHorizontalSignatureWhiteView
//	{
//	}

	// @interface PayPalConfiguration : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface PayPalConfiguration : INSCopying
	{
		// @property (readwrite, copy, nonatomic) NSString * defaultUserEmail;
		[Export ("defaultUserEmail")]
		string DefaultUserEmail { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * defaultUserPhoneCountryCode;
		[Export ("defaultUserPhoneCountryCode")]
		string DefaultUserPhoneCountryCode { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * defaultUserPhoneNumber;
		[Export ("defaultUserPhoneNumber")]
		string DefaultUserPhoneNumber { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * merchantName;
		[Export ("merchantName")]
		string MerchantName { get; set; }

		// @property (readwrite, copy, nonatomic) NSURL * merchantPrivacyPolicyURL;
		[Export ("merchantPrivacyPolicyURL", ArgumentSemantic.Copy)]
		NSURL MerchantPrivacyPolicyURL { get; set; }

		// @property (readwrite, copy, nonatomic) NSURL * merchantUserAgreementURL;
		[Export ("merchantUserAgreementURL", ArgumentSemantic.Copy)]
		NSURL MerchantUserAgreementURL { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL acceptCreditCards;
		[Export ("acceptCreditCards")]
		bool AcceptCreditCards { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * callbackURLScheme;
		[Export ("callbackURLScheme")]
		string CallbackURLScheme { get; set; }

		// @property (assign, readwrite, nonatomic) PayPalShippingAddressOption payPalShippingAddressOption;
		[Export ("payPalShippingAddressOption", ArgumentSemantic.Assign)]
		PayPalShippingAddressOption PayPalShippingAddressOption { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL rememberUser;
		[Export ("rememberUser")]
		bool RememberUser { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * languageOrLocale;
		[Export ("languageOrLocale")]
		string LanguageOrLocale { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL disableBlurWhenBackgrounding;
		[Export ("disableBlurWhenBackgrounding")]
		bool DisableBlurWhenBackgrounding { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL presentingInPopover;
		[Export ("presentingInPopover")]
		bool PresentingInPopover { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL forceDefaultsInSandbox;
		[Export ("forceDefaultsInSandbox")]
		bool ForceDefaultsInSandbox { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * sandboxUserPassword;
		[Export ("sandboxUserPassword")]
		string SandboxUserPassword { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * sandboxUserPin;
		[Export ("sandboxUserPin")]
		string SandboxUserPin { get; set; }
	}

	// @interface PayPalFuturePaymentViewController : UINavigationController
//	[BaseType (typeof(UINavigationController))]
//	interface PayPalFuturePaymentViewController
//	{
//	}

	// typedef void (^PayPalFuturePaymentDelegateCompletionBlock)();
	delegate void PayPalFuturePaymentDelegateCompletionBlock ();

	// @protocol PayPalFuturePaymentDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface PayPalFuturePaymentDelegate
	{
		// @required -(void)payPalFuturePaymentDidCancel:(PayPalFuturePaymentViewController *)futurePaymentViewController;
		[Abstract]
		[Export ("payPalFuturePaymentDidCancel:")]
		void PayPalFuturePaymentDidCancel (PayPalFuturePaymentViewController futurePaymentViewController);

		// @required -(void)payPalFuturePaymentViewController:(PayPalFuturePaymentViewController *)futurePaymentViewController didAuthorizeFuturePayment:(NSDictionary *)futurePaymentAuthorization;
		[Abstract]
		[Export ("payPalFuturePaymentViewController:didAuthorizeFuturePayment:")]
		void PayPalFuturePaymentViewController (PayPalFuturePaymentViewController futurePaymentViewController, NSDictionary futurePaymentAuthorization);

		// @optional -(void)payPalFuturePaymentViewController:(PayPalFuturePaymentViewController *)futurePaymentViewController willAuthorizeFuturePayment:(NSDictionary *)futurePaymentAuthorization completionBlock:(PayPalFuturePaymentDelegateCompletionBlock)completionBlock;
		[Export ("payPalFuturePaymentViewController:willAuthorizeFuturePayment:completionBlock:")]
		void PayPalFuturePaymentViewController (PayPalFuturePaymentViewController futurePaymentViewController, NSDictionary futurePaymentAuthorization, PayPalFuturePaymentDelegateCompletionBlock completionBlock);
	}

	// @interface PayPalFuturePaymentViewController : UINavigationController
	[BaseType (typeof(UINavigationController))]
	interface PayPalFuturePaymentViewController
	{
		// -(instancetype)initWithConfiguration:(PayPalConfiguration *)configuration delegate:(id<PayPalFuturePaymentDelegate>)delegate;
		[Export ("initWithConfiguration:delegate:")]
		IntPtr Constructor (PayPalConfiguration configuration, PayPalFuturePaymentDelegate @delegate);

		[Wrap ("WeakFuturePaymentDelegate")]
		PayPalFuturePaymentDelegate FuturePaymentDelegate { get; }

		// @property (readonly, nonatomic, weak) id<PayPalFuturePaymentDelegate> futurePaymentDelegate;
		[NullAllowed, Export ("futurePaymentDelegate", ArgumentSemantic.Weak)]
		NSObject WeakFuturePaymentDelegate { get; }
	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kPayPalOAuth2ScopeFuturePayments;
		[Field ("kPayPalOAuth2ScopeFuturePayments")]
		NSString kPayPalOAuth2ScopeFuturePayments { get; }

		// extern NSString *const kPayPalOAuth2ScopeProfile;
		[Field ("kPayPalOAuth2ScopeProfile")]
		NSString kPayPalOAuth2ScopeProfile { get; }

		// extern NSString *const kPayPalOAuth2ScopeOpenId;
		[Field ("kPayPalOAuth2ScopeOpenId")]
		NSString kPayPalOAuth2ScopeOpenId { get; }

		// extern NSString *const kPayPalOAuth2ScopePayPalAttributes;
		[Field ("kPayPalOAuth2ScopePayPalAttributes")]
		NSString kPayPalOAuth2ScopePayPalAttributes { get; }

		// extern NSString *const kPayPalOAuth2ScopeEmail;
		[Field ("kPayPalOAuth2ScopeEmail")]
		NSString kPayPalOAuth2ScopeEmail { get; }

		// extern NSString *const kPayPalOAuth2ScopeAddress;
		[Field ("kPayPalOAuth2ScopeAddress")]
		NSString kPayPalOAuth2ScopeAddress { get; }

		// extern NSString *const kPayPalOAuth2ScopePhone;
		[Field ("kPayPalOAuth2ScopePhone")]
		NSString kPayPalOAuth2ScopePhone { get; }
	}

	// @interface PayPalPaymentDetails : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface PayPalPaymentDetails : INSCopying
	{
		// +(PayPalPaymentDetails *)paymentDetailsWithSubtotal:(NSDecimalNumber *)subtotal withShipping:(NSDecimalNumber *)shipping withTax:(NSDecimalNumber *)tax;
		[Static]
		[Export ("paymentDetailsWithSubtotal:withShipping:withTax:")]
		PayPalPaymentDetails PaymentDetailsWithSubtotal (NSDecimalNumber subtotal, NSDecimalNumber shipping, NSDecimalNumber tax);

		// @property (readwrite, copy, nonatomic) NSDecimalNumber * subtotal;
		[Export ("subtotal", ArgumentSemantic.Copy)]
		NSDecimalNumber Subtotal { get; set; }

		// @property (readwrite, copy, nonatomic) NSDecimalNumber * shipping;
		[Export ("shipping", ArgumentSemantic.Copy)]
		NSDecimalNumber Shipping { get; set; }

		// @property (readwrite, copy, nonatomic) NSDecimalNumber * tax;
		[Export ("tax", ArgumentSemantic.Copy)]
		NSDecimalNumber Tax { get; set; }
	}

	// @interface PayPalItem : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface PayPalItem : INSCopying
	{
		// +(PayPalItem *)itemWithName:(NSString *)name withQuantity:(NSUInteger)quantity withPrice:(NSDecimalNumber *)price withCurrency:(NSString *)currency withSku:(NSString *)sku;
		[Static]
		[Export ("itemWithName:withQuantity:withPrice:withCurrency:withSku:")]
		PayPalItem ItemWithName (string name, nuint quantity, NSDecimalNumber price, string currency, string sku);

		// +(NSDecimalNumber *)totalPriceForItems:(NSArray *)items;
		[Static]
		[Export ("totalPriceForItems:")]
		[Verify (StronglyTypedNSArray)]
		NSDecimalNumber TotalPriceForItems (NSObject[] items);

		// @property (readwrite, copy, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; set; }

		// @property (assign, readwrite, nonatomic) NSUInteger quantity;
		[Export ("quantity", ArgumentSemantic.Assign)]
		nuint Quantity { get; set; }

		// @property (readwrite, copy, nonatomic) NSDecimalNumber * price;
		[Export ("price", ArgumentSemantic.Copy)]
		NSDecimalNumber Price { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * currency;
		[Export ("currency")]
		string Currency { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * sku;
		[Export ("sku")]
		string Sku { get; set; }
	}

	// @interface PayPalShippingAddress : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface PayPalShippingAddress : INSCopying
	{
		// +(PayPalShippingAddress *)shippingAddressWithRecipientName:(NSString *)recipientName withLine1:(NSString *)line1 withLine2:(NSString *)line2 withCity:(NSString *)city withState:(NSString *)state withPostalCode:(NSString *)postalCode withCountryCode:(NSString *)countryCode;
		[Static]
		[Export ("shippingAddressWithRecipientName:withLine1:withLine2:withCity:withState:withPostalCode:withCountryCode:")]
		PayPalShippingAddress ShippingAddressWithRecipientName (string recipientName, string line1, string line2, string city, string state, string postalCode, string countryCode);

		// @property (readwrite, copy, nonatomic) NSString * recipientName;
		[Export ("recipientName")]
		string RecipientName { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * line1;
		[Export ("line1")]
		string Line1 { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * line2;
		[Export ("line2")]
		string Line2 { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * city;
		[Export ("city")]
		string City { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * state;
		[Export ("state")]
		string State { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * postalCode;
		[Export ("postalCode")]
		string PostalCode { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * countryCode;
		[Export ("countryCode")]
		string CountryCode { get; set; }
	}

	// @interface PayPalPayment : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface PayPalPayment : INSCopying
	{
		// +(PayPalPayment *)paymentWithAmount:(NSDecimalNumber *)amount currencyCode:(NSString *)currencyCode shortDescription:(NSString *)shortDescription intent:(PayPalPaymentIntent)intent;
		[Static]
		[Export ("paymentWithAmount:currencyCode:shortDescription:intent:")]
		PayPalPayment PaymentWithAmount (NSDecimalNumber amount, string currencyCode, string shortDescription, PayPalPaymentIntent intent);

		// @property (readwrite, copy, nonatomic) NSString * currencyCode;
		[Export ("currencyCode")]
		string CurrencyCode { get; set; }

		// @property (readwrite, copy, nonatomic) NSDecimalNumber * amount;
		[Export ("amount", ArgumentSemantic.Copy)]
		NSDecimalNumber Amount { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * shortDescription;
		[Export ("shortDescription")]
		string ShortDescription { get; set; }

		// @property (assign, readwrite, nonatomic) PayPalPaymentIntent intent;
		[Export ("intent", ArgumentSemantic.Assign)]
		PayPalPaymentIntent Intent { get; set; }

		// @property (readwrite, copy, nonatomic) PayPalPaymentDetails * paymentDetails;
		[Export ("paymentDetails", ArgumentSemantic.Copy)]
		PayPalPaymentDetails PaymentDetails { get; set; }

		// @property (readwrite, copy, nonatomic) NSArray * items;
		[Export ("items", ArgumentSemantic.Copy)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] Items { get; set; }

		// @property (readwrite, copy, nonatomic) PayPalShippingAddress * shippingAddress;
		[Export ("shippingAddress", ArgumentSemantic.Copy)]
		PayPalShippingAddress ShippingAddress { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * invoiceNumber;
		[Export ("invoiceNumber")]
		string InvoiceNumber { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * custom;
		[Export ("custom")]
		string Custom { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * softDescriptor;
		[Export ("softDescriptor")]
		string SoftDescriptor { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * bnCode;
		[Export ("bnCode")]
		string BnCode { get; set; }

		// @property (readonly, assign, nonatomic) BOOL processable;
		[Export ("processable")]
		bool Processable { get; }

		// @property (readonly, copy, nonatomic) NSString * localizedAmountForDisplay;
		[Export ("localizedAmountForDisplay")]
		string LocalizedAmountForDisplay { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * confirmation;
		[Export ("confirmation", ArgumentSemantic.Copy)]
		NSDictionary Confirmation { get; }
	}

	// @interface PayPalPaymentViewController : UINavigationController
//	[BaseType (typeof(UINavigationController))]
//	interface PayPalPaymentViewController
//	{
//	}

	// typedef void (^PayPalPaymentDelegateCompletionBlock)();
	delegate void PayPalPaymentDelegateCompletionBlock ();

	// @protocol PayPalPaymentDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface PayPalPaymentDelegate
	{
		// @required -(void)payPalPaymentDidCancel:(PayPalPaymentViewController *)paymentViewController;
		[Abstract]
		[Export ("payPalPaymentDidCancel:")]
		void PayPalPaymentDidCancel (PayPalPaymentViewController paymentViewController);

		// @required -(void)payPalPaymentViewController:(PayPalPaymentViewController *)paymentViewController didCompletePayment:(PayPalPayment *)completedPayment;
		[Abstract]
		[Export ("payPalPaymentViewController:didCompletePayment:")]
		void PayPalPaymentViewController (PayPalPaymentViewController paymentViewController, PayPalPayment completedPayment);

		// @optional -(void)payPalPaymentViewController:(PayPalPaymentViewController *)paymentViewController willCompletePayment:(PayPalPayment *)completedPayment completionBlock:(PayPalPaymentDelegateCompletionBlock)completionBlock;
		[Export ("payPalPaymentViewController:willCompletePayment:completionBlock:")]
		void PayPalPaymentViewController (PayPalPaymentViewController paymentViewController, PayPalPayment completedPayment, PayPalPaymentDelegateCompletionBlock completionBlock);
	}

	// @interface PayPalPaymentViewController : UINavigationController
	[BaseType (typeof(UINavigationController))]
	interface PayPalPaymentViewController
	{
		// -(instancetype)initWithPayment:(PayPalPayment *)payment configuration:(PayPalConfiguration *)configuration delegate:(id<PayPalPaymentDelegate>)delegate;
		[Export ("initWithPayment:configuration:delegate:")]
		IntPtr Constructor (PayPalPayment payment, PayPalConfiguration configuration, PayPalPaymentDelegate @delegate);

		[Wrap ("WeakPaymentDelegate")]
		PayPalPaymentDelegate PaymentDelegate { get; }

		// @property (readonly, nonatomic, weak) id<PayPalPaymentDelegate> paymentDelegate;
		[NullAllowed, Export ("paymentDelegate", ArgumentSemantic.Weak)]
		NSObject WeakPaymentDelegate { get; }

		// @property (readonly, assign, nonatomic) PayPalPaymentViewControllerState state;
		[Export ("state", ArgumentSemantic.Assign)]
		PayPalPaymentViewControllerState State { get; }
	}

	// @interface PayPalProfileSharingViewController : UINavigationController
//	[BaseType (typeof(UINavigationController))]
//	interface PayPalProfileSharingViewController
//	{
//	}

	// typedef void (^PayPalProfileSharingDelegateCompletionBlock)();
	delegate void PayPalProfileSharingDelegateCompletionBlock ();

	// @protocol PayPalProfileSharingDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface PayPalProfileSharingDelegate
	{
		// @required -(void)userDidCancelPayPalProfileSharingViewController:(PayPalProfileSharingViewController *)profileSharingViewController;
		[Abstract]
		[Export ("userDidCancelPayPalProfileSharingViewController:")]
		void UserDidCancelPayPalProfileSharingViewController (PayPalProfileSharingViewController profileSharingViewController);

		// @required -(void)payPalProfileSharingViewController:(PayPalProfileSharingViewController *)profileSharingViewController userDidLogInWithAuthorization:(NSDictionary *)profileSharingAuthorization;
		[Abstract]
		[Export ("payPalProfileSharingViewController:userDidLogInWithAuthorization:")]
		void PayPalProfileSharingViewController (PayPalProfileSharingViewController profileSharingViewController, NSDictionary profileSharingAuthorization);

		// @optional -(void)payPalProfileSharingViewController:(PayPalProfileSharingViewController *)profileSharingViewController userWillLogInWithAuthorization:(NSDictionary *)profileSharingAuthorization completionBlock:(PayPalProfileSharingDelegateCompletionBlock)completionBlock;
		[Export ("payPalProfileSharingViewController:userWillLogInWithAuthorization:completionBlock:")]
		void PayPalProfileSharingViewController (PayPalProfileSharingViewController profileSharingViewController, NSDictionary profileSharingAuthorization, PayPalProfileSharingDelegateCompletionBlock completionBlock);
	}

	// @interface PayPalProfileSharingViewController : UINavigationController
	[BaseType (typeof(UINavigationController))]
	interface PayPalProfileSharingViewController
	{
		// -(instancetype)initWithScopeValues:(NSSet *)scopeValues configuration:(PayPalConfiguration *)configuration delegate:(id<PayPalProfileSharingDelegate>)delegate;
		[Export ("initWithScopeValues:configuration:delegate:")]
		IntPtr Constructor (NSSet scopeValues, PayPalConfiguration configuration, PayPalProfileSharingDelegate @delegate);

		[Wrap ("WeakProfileSharingDelegate")]
		PayPalProfileSharingDelegate ProfileSharingDelegate { get; }

		// @property (readonly, nonatomic, weak) id<PayPalProfileSharingDelegate> profileSharingDelegate;
		[NullAllowed, Export ("profileSharingDelegate", ArgumentSemantic.Weak)]
		NSObject WeakProfileSharingDelegate { get; }
	}

	// @interface PayPalTouchResult : NSObject
	[BaseType (typeof(NSObject))]
	interface PayPalTouchResult
	{
		// @property (readonly, assign, nonatomic) PayPalTouchResultType resultType;
		[Export ("resultType", ArgumentSemantic.Assign)]
		PayPalTouchResultType ResultType { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * authorization;
		[Export ("authorization", ArgumentSemantic.Copy)]
		NSDictionary Authorization { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * error;
		[Export ("error", ArgumentSemantic.Copy)]
		NSDictionary Error { get; }
	}

	// @interface PayPalTouch : NSObject
	[BaseType (typeof(NSObject))]
	interface PayPalTouch
	{
	}

	// @interface PayPalTouch : NSObject
	[BaseType (typeof(NSObject))]
	interface PayPalTouch
	{
		// +(BOOL)canAppSwitchForUrlScheme:(NSString *)scheme;
		[Static]
		[Export ("canAppSwitchForUrlScheme:")]
		bool CanAppSwitchForUrlScheme (string scheme);

		// +(BOOL)authorizeFuturePayments:(PayPalConfiguration *)configuration __attribute__((deprecated("Please use authorizeScopeValues:configuration: instead")));
		[Static]
		[Export ("authorizeFuturePayments:")]
		bool AuthorizeFuturePayments (PayPalConfiguration configuration);

		// +(BOOL)authorizeScopeValues:(NSSet *)scopeValues configuration:(PayPalConfiguration *)configuration;
		[Static]
		[Export ("authorizeScopeValues:configuration:")]
		bool AuthorizeScopeValues (NSSet scopeValues, PayPalConfiguration configuration);

		// +(PayPalTouchResult *)parseAppSwitchURL:(NSURL *)url;
		[Static]
		[Export ("parseAppSwitchURL:")]
		PayPalTouchResult ParseAppSwitchURL (NSURL url);

		// +(BOOL)canHandleURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication;
		[Static]
		[Export ("canHandleURL:sourceApplication:")]
		bool CanHandleURL (NSURL url, string sourceApplication);
	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const PayPalEnvironmentProduction;
		[Field ("PayPalEnvironmentProduction")]
		NSString PayPalEnvironmentProduction { get; }

		// extern NSString *const PayPalEnvironmentSandbox;
		[Field ("PayPalEnvironmentSandbox")]
		NSString PayPalEnvironmentSandbox { get; }

		// extern NSString *const PayPalEnvironmentNoNetwork;
		[Field ("PayPalEnvironmentNoNetwork")]
		NSString PayPalEnvironmentNoNetwork { get; }
	}

	// @interface PayPalMobile : NSObject
	[BaseType (typeof(NSObject))]
	interface PayPalMobile
	{
		// +(void)initializeWithClientIdsForEnvironments:(NSDictionary *)clientIdsForEnvironments;
		[Static]
		[Export ("initializeWithClientIdsForEnvironments:")]
		void InitializeWithClientIdsForEnvironments (NSDictionary clientIdsForEnvironments);

		// +(void)preconnectWithEnvironment:(NSString *)environment;
		[Static]
		[Export ("preconnectWithEnvironment:")]
		void PreconnectWithEnvironment (string environment);

		// +(NSString *)clientMetadataID;
		[Static]
		[Export ("clientMetadataID")]
		[Verify (MethodToProperty)]
		string ClientMetadataID { get; }

		// +(NSString *)applicationCorrelationIDForEnvironment:(NSString *)environment __attribute__((deprecated("Use clientMetadataID instead.")));
		[Static]
		[Export ("applicationCorrelationIDForEnvironment:")]
		string ApplicationCorrelationIDForEnvironment (string environment);

		// +(void)clearAllUserData;
		[Static]
		[Export ("clearAllUserData")]
		void ClearAllUserData ();

		// +(NSString *)libraryVersion;
		[Static]
		[Export ("libraryVersion")]
		[Verify (MethodToProperty)]
		string LibraryVersion { get; }

		// +(void)addEnvironments:(NSDictionary *)environments;
		[Static]
		[Export ("addEnvironments:")]
		void AddEnvironments (NSDictionary environments);

		// +(NSDictionary *)availableEnvironments;
		[Static]
		[Export ("availableEnvironments")]
		[Verify (MethodToProperty)]
		NSDictionary AvailableEnvironments { get; }

		// +(void)setClientId:(NSString *)clientId forEnvironment:(NSString *)environment;
		[Static]
		[Export ("setClientId:forEnvironment:")]
		void SetClientId (string clientId, string environment);
	}

	// @interface  (BTPayPalViewController) <PayPalProfileSharingDelegate>
	[Category]
	[BaseType (typeof(BTPayPalViewController))]
	interface BTPayPalViewController_ : IPayPalProfileSharingDelegate
	{
		// @property (readwrite, nonatomic, strong) PayPalProfileSharingViewController * payPalProfileSharingViewController;
		[Export ("payPalProfileSharingViewController")]
		PayPalProfileSharingViewController PayPalProfileSharingViewController { get; set; }
	}

	// @interface BTClient : NSObject <NSCoding, NSCopying>
//	[BaseType (typeof(NSObject))]
//	interface BTClient : INSCoding, INSCopying
//	{
//	}

	// @protocol BTPaymentMethodCreationDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTPaymentMethodCreationDelegate
	{
		// @required -(void)paymentMethodCreator:(id)sender requestsPresentationOfViewController:(UIViewController *)viewController;
		[Abstract]
		[Export ("paymentMethodCreator:requestsPresentationOfViewController:")]
		void PaymentMethodCreator (NSObject sender, UIViewController viewController);

		// @required -(void)paymentMethodCreator:(id)sender requestsDismissalOfViewController:(UIViewController *)viewController;
		[Abstract]
		[Export ("paymentMethodCreator:requestsDismissalOfViewController:")]
		void PaymentMethodCreator (NSObject sender, UIViewController viewController);

		// @required -(void)paymentMethodCreatorWillPerformAppSwitch:(id)sender;
		[Abstract]
		[Export ("paymentMethodCreatorWillPerformAppSwitch:")]
		void PaymentMethodCreatorWillPerformAppSwitch (NSObject sender);

		// @required -(void)paymentMethodCreatorWillProcess:(id)sender;
		[Abstract]
		[Export ("paymentMethodCreatorWillProcess:")]
		void PaymentMethodCreatorWillProcess (NSObject sender);

		// @required -(void)paymentMethodCreatorDidCancel:(id)sender;
		[Abstract]
		[Export ("paymentMethodCreatorDidCancel:")]
		void PaymentMethodCreatorDidCancel (NSObject sender);

		// @required -(void)paymentMethodCreator:(id)sender didCreatePaymentMethod:(BTPaymentMethod *)paymentMethod;
		[Abstract]
		[Export ("paymentMethodCreator:didCreatePaymentMethod:")]
		void PaymentMethodCreator (NSObject sender, BTPaymentMethod paymentMethod);

		// @required -(void)paymentMethodCreator:(id)sender didFailWithError:(NSError *)error;
		[Abstract]
		[Export ("paymentMethodCreator:didFailWithError:")]
		void PaymentMethodCreator (NSObject sender, NSError error);
	}

	// @interface BTPaymentApplePayProvider : NSObject
	[BaseType (typeof(NSObject))]
	interface BTPaymentApplePayProvider
	{
		// -(instancetype)initWithClient:(BTClient *)client __attribute__((objc_designated_initializer));
		[Export ("initWithClient:")]
		IntPtr Constructor (BTClient client);

		[Wrap ("WeakDelegate")]
		BTPaymentMethodCreationDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTPaymentMethodCreationDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(BOOL)canAuthorizeApplePayPayment;
		[Export ("canAuthorizeApplePayPayment")]
		[Verify (MethodToProperty)]
		bool CanAuthorizeApplePayPayment { get; }

		// -(void)authorizeApplePay;
		[Export ("authorizeApplePay")]
		void AuthorizeApplePay ();
	}

	// @interface  (BTPaymentApplePayProvider)
	[Category]
	[BaseType (typeof(BTPaymentApplePayProvider))]
	interface BTPaymentApplePayProvider_
	{
		// +(BOOL)isSimulator;
		[Static]
		[Export ("isSimulator")]
		[Verify (MethodToProperty)]
		bool IsSimulator { get; }

		// -(BOOL)paymentAuthorizationViewControllerCanMakePayments;
		[Export ("paymentAuthorizationViewControllerCanMakePayments")]
		[Verify (MethodToProperty)]
		bool PaymentAuthorizationViewControllerCanMakePayments { get; }
	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const BTPaymentProviderErrorDomain;
		[Field ("BTPaymentProviderErrorDomain")]
		NSString BTPaymentProviderErrorDomain { get; }

		// extern enum BTPaymentProviderErrorCode BTPaymentProviderErrorCode;
		[Field ("BTPaymentProviderErrorCode")]
		BTPaymentProviderErrorCode BTPaymentProviderErrorCode { get; }
	}

	// @interface BTPaymentProvider : NSObject
	[BaseType (typeof(NSObject))]
	interface BTPaymentProvider
	{
		// -(instancetype)initWithClient:(BTClient *)client;
		[Export ("initWithClient:")]
		IntPtr Constructor (BTClient client);

		// @property (nonatomic, strong) BTClient * client;
		[Export ("client", ArgumentSemantic.Strong)]
		BTClient Client { get; set; }

		[Wrap ("WeakDelegate")]
		BTPaymentMethodCreationDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTPaymentMethodCreationDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)createPaymentMethod:(BTPaymentProviderType)type;
		[Export ("createPaymentMethod:")]
		void CreatePaymentMethod (BTPaymentProviderType type);

		// -(void)createPaymentMethod:(BTPaymentProviderType)type options:(BTPaymentMethodCreationOptions)options;
		[Export ("createPaymentMethod:options:")]
		void CreatePaymentMethod (BTPaymentProviderType type, BTPaymentMethodCreationOptions options);

		// -(BOOL)canCreatePaymentMethodWithProviderType:(BTPaymentProviderType)type;
		[Export ("canCreatePaymentMethodWithProviderType:")]
		bool CanCreatePaymentMethodWithProviderType (BTPaymentProviderType type);

		// @property (assign, nonatomic) BTPaymentProviderStatus status;
		[Export ("status", ArgumentSemantic.Assign)]
		BTPaymentProviderStatus Status { get; set; }
	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString * kReachabilityChangedNotification;
		[Field ("kReachabilityChangedNotification")]
		NSString kReachabilityChangedNotification { get; }
	}

	// @interface BTReachability : NSObject
	[BaseType (typeof(NSObject))]
	interface BTReachability
	{
		// +(instancetype)reachabilityWithHostName:(NSString *)hostName;
		[Static]
		[Export ("reachabilityWithHostName:")]
		BTReachability ReachabilityWithHostName (string hostName);

		// +(instancetype)reachabilityWithAddress:(const struct sockaddr_in *)hostAddress;
		[Static]
		[Export ("reachabilityWithAddress:")]
		unsafe BTReachability ReachabilityWithAddress (sockaddr_in* hostAddress);

		// +(instancetype)reachabilityForInternetConnection;
		[Static]
		[Export ("reachabilityForInternetConnection")]
		BTReachability ReachabilityForInternetConnection ();

		// +(instancetype)reachabilityForLocalWiFi;
		[Static]
		[Export ("reachabilityForLocalWiFi")]
		BTReachability ReachabilityForLocalWiFi ();

		// -(BOOL)startNotifier;
		[Export ("startNotifier")]
		[Verify (MethodToProperty)]
		bool StartNotifier { get; }

		// -(void)stopNotifier;
		[Export ("stopNotifier")]
		void StopNotifier ();

		// -(BTNetworkStatus)currentReachabilityStatus;
		[Export ("currentReachabilityStatus")]
		[Verify (MethodToProperty)]
		BTNetworkStatus CurrentReachabilityStatus { get; }

		// -(BOOL)connectionRequired;
		[Export ("connectionRequired")]
		[Verify (MethodToProperty)]
		bool ConnectionRequired { get; }
	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString * BTThreeDSecureErrorDomain;
		[Field ("BTThreeDSecureErrorDomain")]
		NSString BTThreeDSecureErrorDomain { get; }
	}

	// @interface BTThreeDSecure : NSObject
	[BaseType (typeof(NSObject))]
	interface BTThreeDSecure
	{
		// -(instancetype)initWithClient:(BTClient *)client delegate:(id<BTPaymentMethodCreationDelegate>)delegate __attribute__((objc_designated_initializer));
		[Export ("initWithClient:delegate:")]
		IntPtr Constructor (BTClient client, BTPaymentMethodCreationDelegate @delegate);

		[Wrap ("WeakDelegate")]
		BTPaymentMethodCreationDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTPaymentMethodCreationDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)verifyCardWithNonce:(NSString *)nonce amount:(NSDecimalNumber *)amount;
		[Export ("verifyCardWithNonce:amount:")]
		void VerifyCardWithNonce (string nonce, NSDecimalNumber amount);

		// -(void)verifyCard:(BTCardPaymentMethod *)card amount:(NSDecimalNumber *)amount;
		[Export ("verifyCard:amount:")]
		void VerifyCard (BTCardPaymentMethod card, NSDecimalNumber amount);

		// -(void)verifyCardWithDetails:(BTClientCardRequest *)details amount:(NSDecimalNumber *)amount;
		[Export ("verifyCardWithDetails:amount:")]
		void VerifyCardWithDetails (BTClientCardRequest details, NSDecimalNumber amount);
	}

	// @interface BTWebViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface BTWebViewController
	{
		// -(instancetype)initWithRequest:(NSURLRequest *)request __attribute__((objc_designated_initializer));
		[Export ("initWithRequest:")]
		IntPtr Constructor (NSURLRequest request);

		// -(BOOL)webView:(UIWebView *)webView shouldStartLoadWithRequest:(NSURLRequest *)request navigationType:(UIWebViewNavigationType)navigationType __attribute__((objc_requires_super));
		[Export ("webView:shouldStartLoadWithRequest:navigationType:")]
		bool WebView (UIWebView webView, NSURLRequest request, UIWebViewNavigationType navigationType);

		// -(void)webViewDidStartLoad:(UIWebView *)webView __attribute__((objc_requires_super));
		[Export ("webViewDidStartLoad:")]
		void WebViewDidStartLoad (UIWebView webView);

		// -(void)webViewDidFinishLoad:(UIWebView *)webView __attribute__((objc_requires_super));
		[Export ("webViewDidFinishLoad:")]
		void WebViewDidFinishLoad (UIWebView webView);

		// -(void)webView:(UIWebView *)webView didFailLoadWithError:(NSError *)error;
		[Export ("webView:didFailLoadWithError:")]
		void WebView (UIWebView webView, NSError error);
	}

	// @protocol BTThreeDSecureAuthenticationViewControllerDelegate <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface BTThreeDSecureAuthenticationViewControllerDelegate
//	{
//	}

	// @interface BTThreeDSecureAuthenticationViewController : BTWebViewController
	[BaseType (typeof(BTWebViewController))]
	interface BTThreeDSecureAuthenticationViewController
	{
		// -(instancetype)initWithLookupResult:(BTThreeDSecureLookupResult *)lookupResult __attribute__((objc_designated_initializer));
		[Export ("initWithLookupResult:")]
		IntPtr Constructor (BTThreeDSecureLookupResult lookupResult);

		[Wrap ("WeakDelegate")]
		BTThreeDSecureAuthenticationViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTThreeDSecureAuthenticationViewControllerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

	// @protocol BTThreeDSecureAuthenticationViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTThreeDSecureAuthenticationViewControllerDelegate
	{
		// @required -(void)threeDSecureViewController:(BTThreeDSecureAuthenticationViewController *)viewController didAuthenticateCard:(BTCardPaymentMethod *)card completion:(void (^)(BTThreeDSecureViewControllerCompletionStatus))completionBlock;
		[Abstract]
		[Export ("threeDSecureViewController:didAuthenticateCard:completion:")]
		void ThreeDSecureViewController (BTThreeDSecureAuthenticationViewController viewController, BTCardPaymentMethod card, Action<BTThreeDSecureViewControllerCompletionStatus> completionBlock);

		// @required -(void)threeDSecureViewController:(BTThreeDSecureAuthenticationViewController *)viewController didFailWithError:(NSError *)error;
		[Abstract]
		[Export ("threeDSecureViewController:didFailWithError:")]
		void ThreeDSecureViewController (BTThreeDSecureAuthenticationViewController viewController, NSError error);

		// @required -(void)threeDSecureViewControllerDidFinish:(BTThreeDSecureAuthenticationViewController *)viewController;
		[Abstract]
		[Export ("threeDSecureViewControllerDidFinish:")]
		void ThreeDSecureViewControllerDidFinish (BTThreeDSecureAuthenticationViewController viewController);

		// @optional -(void)threeDSecureViewController:(BTThreeDSecureAuthenticationViewController *)viewController didPresentErrorToUserForURLRequest:(NSURLRequest *)request;
		[Export ("threeDSecureViewController:didPresentErrorToUserForURLRequest:")]
		void ThreeDSecureViewController (BTThreeDSecureAuthenticationViewController viewController, NSURLRequest request);
	}

	// @interface BTThreeDSecureLocalizedString : NSObject
	[BaseType (typeof(NSObject))]
	interface BTThreeDSecureLocalizedString
	{
		// +(NSString *)ERROR_ALERT_OK_BUTTON_TEXT;
		[Static]
		[Export ("ERROR_ALERT_OK_BUTTON_TEXT")]
		[Verify (MethodToProperty)]
		string ERROR_ALERT_OK_BUTTON_TEXT { get; }

		// +(NSString *)ERROR_ALERT_CANCEL_BUTTON_TEXT;
		[Static]
		[Export ("ERROR_ALERT_CANCEL_BUTTON_TEXT")]
		[Verify (MethodToProperty)]
		string ERROR_ALERT_CANCEL_BUTTON_TEXT { get; }
	}

	// @interface BTThreeDSecureResponse : NSObject
	[BaseType (typeof(NSObject))]
	interface BTThreeDSecureResponse
	{
		// @property (assign, nonatomic) BOOL success;
		[Export ("success")]
		bool Success { get; set; }

		// @property (nonatomic, strong) NSDictionary * threeDSecureInfo;
		[Export ("threeDSecureInfo", ArgumentSemantic.Strong)]
		NSDictionary ThreeDSecureInfo { get; set; }

		// @property (nonatomic, strong) BTCardPaymentMethod * paymentMethod;
		[Export ("paymentMethod", ArgumentSemantic.Strong)]
		BTCardPaymentMethod PaymentMethod { get; set; }

		// @property (copy, nonatomic) NSString * errorMessage;
		[Export ("errorMessage")]
		string ErrorMessage { get; set; }
	}

	// @interface BTUICardVectorArtView : BTUIVectorArtView
	[BaseType (typeof(BTUIVectorArtView))]
	interface BTUICardVectorArtView
	{
		// @property (nonatomic, strong) UIColor * highlightColor;
		[Export ("highlightColor", ArgumentSemantic.Strong)]
		UIColor HighlightColor { get; set; }
	}

	// @interface BTUIAmExVectorArtView : BTUICardVectorArtView
//	[BaseType (typeof(BTUICardVectorArtView))]
//	interface BTUIAmExVectorArtView
//	{
//	}
//
//	// @interface BTUICVVBackVectorArtView : BTUICardVectorArtView
//	[BaseType (typeof(BTUICardVectorArtView))]
//	interface BTUICVVBackVectorArtView
//	{
//	}
//
//	// @interface BTUICVVFrontVectorArtView : BTUICardVectorArtView
//	[BaseType (typeof(BTUICardVectorArtView))]
//	interface BTUICVVFrontVectorArtView
//	{
//	}
//
//	// @protocol BTUIFormFieldDelegate <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface BTUIFormFieldDelegate
//	{
//	}

	// @interface BTUIFormField : BTUIThemedView <UITextFieldDelegate>
	[BaseType (typeof(BTUIThemedView))]
	interface BTUIFormField : IUITextFieldDelegate
	{
		// -(void)updateAppearance;
		[Export ("updateAppearance")]
		void UpdateAppearance ();

		[Wrap ("WeakDelegate")]
		BTUIFormFieldDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTUIFormFieldDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) BOOL vibrateOnInvalidInput;
		[Export ("vibrateOnInvalidInput")]
		bool VibrateOnInvalidInput { get; set; }

		// @property (readonly, assign, nonatomic) BOOL valid;
		[Export ("valid")]
		bool Valid { get; }

		// @property (readonly, assign, nonatomic) BOOL entryComplete;
		[Export ("entryComplete")]
		bool EntryComplete { get; }

		// @property (assign, nonatomic) BOOL displayAsValid;
		[Export ("displayAsValid")]
		bool DisplayAsValid { get; set; }

		// @property (assign, nonatomic) BOOL bottomBorder;
		[Export ("bottomBorder")]
		bool BottomBorder { get; set; }

		// @property (readonly, assign, nonatomic) BOOL backspace;
		[Export ("backspace")]
		bool Backspace { get; }

		// @property (readonly, nonatomic, strong) UITextField * textField;
		[Export ("textField", ArgumentSemantic.Strong)]
		UITextField TextField { get; }

		// @property (nonatomic, strong) UIView * accessoryView;
		[Export ("accessoryView", ArgumentSemantic.Strong)]
		UIView AccessoryView { get; set; }
	}

	// @protocol BTUIFormFieldDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTUIFormFieldDelegate
	{
		// @required -(void)formFieldDidChange:(BTUIFormField *)formField;
		[Abstract]
		[Export ("formFieldDidChange:")]
		void FormFieldDidChange (BTUIFormField formField);

		// @required -(void)formFieldDidDeleteWhileEmpty:(BTUIFormField *)formField;
		[Abstract]
		[Export ("formFieldDidDeleteWhileEmpty:")]
		void FormFieldDidDeleteWhileEmpty (BTUIFormField formField);

		// @optional -(BOOL)formFieldShouldReturn:(BTUIFormField *)formField;
		[Export ("formFieldShouldReturn:")]
		bool FormFieldShouldReturn (BTUIFormField formField);
	}

	// @interface BTUILocalizedString : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUILocalizedString
	{
		// +(NSString *)CARD_NUMBER_PLACEHOLDER;
		[Static]
		[Export ("CARD_NUMBER_PLACEHOLDER")]
		[Verify (MethodToProperty)]
		string CARD_NUMBER_PLACEHOLDER { get; }

		// +(NSString *)CVV_FIELD_PLACEHOLDER;
		[Static]
		[Export ("CVV_FIELD_PLACEHOLDER")]
		[Verify (MethodToProperty)]
		string CVV_FIELD_PLACEHOLDER { get; }

		// +(NSString *)EXPIRY_PLACEHOLDER_FOUR_DIGIT_YEAR;
		[Static]
		[Export ("EXPIRY_PLACEHOLDER_FOUR_DIGIT_YEAR")]
		[Verify (MethodToProperty)]
		string EXPIRY_PLACEHOLDER_FOUR_DIGIT_YEAR { get; }

		// +(NSString *)EXPIRY_PLACEHOLDER_TWO_DIGIT_YEAR;
		[Static]
		[Export ("EXPIRY_PLACEHOLDER_TWO_DIGIT_YEAR")]
		[Verify (MethodToProperty)]
		string EXPIRY_PLACEHOLDER_TWO_DIGIT_YEAR { get; }

		// +(NSString *)PAYPAL_CARD_BRAND;
		[Static]
		[Export ("PAYPAL_CARD_BRAND")]
		[Verify (MethodToProperty)]
		string PAYPAL_CARD_BRAND { get; }

		// +(NSString *)POSTAL_CODE_PLACEHOLDER;
		[Static]
		[Export ("POSTAL_CODE_PLACEHOLDER")]
		[Verify (MethodToProperty)]
		string POSTAL_CODE_PLACEHOLDER { get; }

		// +(NSString *)TOP_LEVEL_ERROR_ALERT_VIEW_OK_BUTTON_TEXT;
		[Static]
		[Export ("TOP_LEVEL_ERROR_ALERT_VIEW_OK_BUTTON_TEXT")]
		[Verify (MethodToProperty)]
		string TOP_LEVEL_ERROR_ALERT_VIEW_OK_BUTTON_TEXT { get; }

		// +(NSString *)CARD_TYPE_AMERICAN_EXPRESS;
		[Static]
		[Export ("CARD_TYPE_AMERICAN_EXPRESS")]
		[Verify (MethodToProperty)]
		string CARD_TYPE_AMERICAN_EXPRESS { get; }

		// +(NSString *)CARD_TYPE_DISCOVER;
		[Static]
		[Export ("CARD_TYPE_DISCOVER")]
		[Verify (MethodToProperty)]
		string CARD_TYPE_DISCOVER { get; }

		// +(NSString *)CARD_TYPE_DINERS_CLUB;
		[Static]
		[Export ("CARD_TYPE_DINERS_CLUB")]
		[Verify (MethodToProperty)]
		string CARD_TYPE_DINERS_CLUB { get; }

		// +(NSString *)CARD_TYPE_MASTER_CARD;
		[Static]
		[Export ("CARD_TYPE_MASTER_CARD")]
		[Verify (MethodToProperty)]
		string CARD_TYPE_MASTER_CARD { get; }

		// +(NSString *)CARD_TYPE_VISA;
		[Static]
		[Export ("CARD_TYPE_VISA")]
		[Verify (MethodToProperty)]
		string CARD_TYPE_VISA { get; }

		// +(NSString *)CARD_TYPE_JCB;
		[Static]
		[Export ("CARD_TYPE_JCB")]
		[Verify (MethodToProperty)]
		string CARD_TYPE_JCB { get; }

		// +(NSString *)CARD_TYPE_MAESTRO;
		[Static]
		[Export ("CARD_TYPE_MAESTRO")]
		[Verify (MethodToProperty)]
		string CARD_TYPE_MAESTRO { get; }

		// +(NSString *)CARD_TYPE_UNION_PAY;
		[Static]
		[Export ("CARD_TYPE_UNION_PAY")]
		[Verify (MethodToProperty)]
		string CARD_TYPE_UNION_PAY { get; }

		// +(NSString *)CARD_TYPE_SWITCH;
		[Static]
		[Export ("CARD_TYPE_SWITCH")]
		[Verify (MethodToProperty)]
		string CARD_TYPE_SWITCH { get; }

		// +(NSString *)CARD_TYPE_SOLO;
		[Static]
		[Export ("CARD_TYPE_SOLO")]
		[Verify (MethodToProperty)]
		string CARD_TYPE_SOLO { get; }

		// +(NSString *)CARD_TYPE_LASER;
		[Static]
		[Export ("CARD_TYPE_LASER")]
		[Verify (MethodToProperty)]
		string CARD_TYPE_LASER { get; }

		// +(NSString *)PAYMENT_METHOD_TYPE_PAYPAL;
		[Static]
		[Export ("PAYMENT_METHOD_TYPE_PAYPAL")]
		[Verify (MethodToProperty)]
		string PAYMENT_METHOD_TYPE_PAYPAL { get; }
	}

	// @interface BTUICardType : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUICardType
	{
		// +(instancetype)cardTypeForBrand:(NSString *)brand;
		[Static]
		[Export ("cardTypeForBrand:")]
		BTUICardType CardTypeForBrand (string brand);

		// +(instancetype)cardTypeForNumber:(NSString *)number;
		[Static]
		[Export ("cardTypeForNumber:")]
		BTUICardType CardTypeForNumber (string number);

		// +(NSArray *)possibleCardTypesForNumber:(NSString *)number;
		[Static]
		[Export ("possibleCardTypesForNumber:")]
		[Verify (StronglyTypedNSArray)]
		NSObject[] PossibleCardTypesForNumber (string number);

		// -(BOOL)validNumber:(NSString *)number;
		[Export ("validNumber:")]
		bool ValidNumber (string number);

		// -(BOOL)completeNumber:(NSString *)number;
		[Export ("completeNumber:")]
		bool CompleteNumber (string number);

		// -(BOOL)validCvv:(NSString *)cvv;
		[Export ("validCvv:")]
		bool ValidCvv (string cvv);

		// -(NSAttributedString *)formatNumber:(NSString *)input;
		[Export ("formatNumber:")]
		NSAttributedString FormatNumber (string input);

		// -(NSAttributedString *)formatNumber:(NSString *)input kerning:(CGFloat)kerning;
		[Export ("formatNumber:kerning:")]
		NSAttributedString FormatNumber (string input, nfloat kerning);

		// +(NSUInteger)maxNumberLength;
		[Static]
		[Export ("maxNumberLength")]
		[Verify (MethodToProperty)]
		nuint MaxNumberLength { get; }

		// @property (readonly, copy, nonatomic) NSString * brand;
		[Export ("brand")]
		string Brand { get; }

		// @property (readonly, nonatomic, strong) NSArray * validNumberPrefixes;
		[Export ("validNumberPrefixes", ArgumentSemantic.Strong)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] ValidNumberPrefixes { get; }

		// @property (readonly, nonatomic, strong) NSIndexSet * validNumberLengths;
		[Export ("validNumberLengths", ArgumentSemantic.Strong)]
		NSIndexSet ValidNumberLengths { get; }

		// @property (readonly, assign, nonatomic) NSUInteger validCvvLength;
		[Export ("validCvvLength", ArgumentSemantic.Assign)]
		nuint ValidCvvLength { get; }

		// @property (readonly, nonatomic, strong) NSArray * formatSpaces;
		[Export ("formatSpaces", ArgumentSemantic.Strong)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] FormatSpaces { get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxNumberLength;
		[Export ("maxNumberLength", ArgumentSemantic.Assign)]
		nuint MaxNumberLength { get; }
	}

	// @interface BTUICardCvvField : BTUIFormField
	[BaseType (typeof(BTUIFormField))]
	interface BTUICardCvvField
	{
		// @property (nonatomic, strong) BTUICardType * cardType;
		[Export ("cardType", ArgumentSemantic.Strong)]
		BTUICardType CardType { get; set; }

		// @property (readonly, nonatomic, strong) NSString * cvv;
		[Export ("cvv", ArgumentSemantic.Strong)]
		string Cvv { get; }
	}

	// @interface BTUICardExpirationValidator : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUICardExpirationValidator
	{
		// +(BOOL)month:(NSUInteger)month year:(NSUInteger)year validForDate:(NSDate *)date;
		[Static]
		[Export ("month:year:validForDate:")]
		bool Month (nuint month, nuint year, NSDate date);
	}

	// @interface BTUICardExpiryField : BTUIFormField
	[BaseType (typeof(BTUIFormField))]
	interface BTUICardExpiryField
	{
		// @property (readonly, nonatomic, strong) NSString * expirationMonth;
		[Export ("expirationMonth", ArgumentSemantic.Strong)]
		string ExpirationMonth { get; }

		// @property (readonly, nonatomic, strong) NSString * expirationYear;
		[Export ("expirationYear", ArgumentSemantic.Strong)]
		string ExpirationYear { get; }
	}

	// @interface BTUICardExpiryFormat : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUICardExpiryFormat
	{
		// @property (copy, nonatomic) NSString * value;
		[Export ("value")]
		string Value { get; set; }

		// @property (assign, nonatomic) NSUInteger cursorLocation;
		[Export ("cursorLocation", ArgumentSemantic.Assign)]
		nuint CursorLocation { get; set; }

		// @property (assign, nonatomic) BOOL backspace;
		[Export ("backspace")]
		bool Backspace { get; set; }

		// -(void)formattedValue:(NSString **)value cursorLocation:(NSUInteger *)cursorLocation;
		[Export ("formattedValue:cursorLocation:")]
		unsafe void FormattedValue (out string value, nuint* cursorLocation);
	}

	// @interface BTUICardHint : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTUICardHint
	{
		// @property (assign, nonatomic) BTUIPaymentMethodType cardType;
		[Export ("cardType", ArgumentSemantic.Assign)]
		BTUIPaymentMethodType CardType { get; set; }

		// @property (assign, nonatomic) BTCardHintDisplayMode displayMode;
		[Export ("displayMode", ArgumentSemantic.Assign)]
		BTCardHintDisplayMode DisplayMode { get; set; }

		// @property (assign, nonatomic) BOOL highlighted;
		[Export ("highlighted")]
		bool Highlighted { get; set; }

		// -(void)setHighlighted:(BOOL)highlighted animated:(BOOL)animated;
		[Export ("setHighlighted:animated:")]
		void SetHighlighted (bool highlighted, bool animated);

		// -(void)setCardType:(BTUIPaymentMethodType)cardType animated:(BOOL)animated;
		[Export ("setCardType:animated:")]
		void SetCardType (BTUIPaymentMethodType cardType, bool animated);

		// -(void)setDisplayMode:(BTCardHintDisplayMode)displayMode animated:(BOOL)animated;
		[Export ("setDisplayMode:animated:")]
		void SetDisplayMode (BTCardHintDisplayMode displayMode, bool animated);
	}

	// @interface BTUICardNumberField : BTUIFormField
	[BaseType (typeof(BTUIFormField))]
	interface BTUICardNumberField
	{
		// @property (readonly, nonatomic, strong) BTUICardType * cardType;
		[Export ("cardType", ArgumentSemantic.Strong)]
		BTUICardType CardType { get; }

		// @property (readonly, nonatomic, strong) NSString * number;
		[Export ("number", ArgumentSemantic.Strong)]
		string Number { get; }
	}

	// @interface BTUICardPostalCodeField : BTUIFormField
	[BaseType (typeof(BTUIFormField))]
	interface BTUICardPostalCodeField
	{
		// @property (readonly, nonatomic, strong) NSString * postalCode;
		[Export ("postalCode", ArgumentSemantic.Strong)]
		string PostalCode { get; }

		// @property (assign, nonatomic) BOOL nonDigitsSupported;
		[Export ("nonDigitsSupported")]
		bool NonDigitsSupported { get; set; }
	}

//	// @interface BTUIDinersClubVectorArtView : BTUICardVectorArtView
//	[BaseType (typeof(BTUICardVectorArtView))]
//	interface BTUIDinersClubVectorArtView
//	{
//	}
//
//	// @interface BTUIDiscoverVectorArtView : BTUICardVectorArtView
//	[BaseType (typeof(BTUICardVectorArtView))]
//	interface BTUIDiscoverVectorArtView
//	{
//	}

	// @interface BTUIFloatLabel : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTUIFloatLabel
	{
		// @property (readonly, nonatomic, strong) UILabel * label;
		[Export ("label", ArgumentSemantic.Strong)]
		UILabel Label { get; }

		// -(void)showWithAnimation:(BOOL)shouldAnimate;
		[Export ("showWithAnimation:")]
		void ShowWithAnimation (bool shouldAnimate);

		// -(void)hideWithAnimation:(BOOL)shouldAnimate;
		[Export ("hideWithAnimation:")]
		void HideWithAnimation (bool shouldAnimate);
	}

	// @interface  (BTUIFormField)
	[Category]
	[BaseType (typeof(BTUIFormField))]
	interface BTUIFormField_
	{
		// @property (readonly, nonatomic, strong) UITextField * textField;
		[Export ("textField")]
		UITextField TextField { get; }

		// @property (nonatomic, strong) UIView * accessoryView;
		[Export ("accessoryView")]
		UIView AccessoryView { get; set; }

		// -(void)fieldContentDidChange;
		[Export ("fieldContentDidChange")]
		void FieldContentDidChange ();

		// -(void)setThemedPlaceholder:(NSString *)placeholder;
		[Export ("setThemedPlaceholder:")]
		void SetThemedPlaceholder (string placeholder);

		// -(void)setThemedAttributedPlaceholder:(NSAttributedString *)placeholder;
		[Export ("setThemedAttributedPlaceholder:")]
		void SetThemedAttributedPlaceholder (NSAttributedString placeholder);
	}

	// @interface BTUIHorizontalButtonStackCollectionViewFlowLayout : UICollectionViewFlowLayout
	[BaseType (typeof(UICollectionViewFlowLayout))]
	interface BTUIHorizontalButtonStackCollectionViewFlowLayout
	{
	}

	// @interface BTUIHorizontalButtonStackSeparatorLineView : UICollectionReusableView
	[BaseType (typeof(UICollectionReusableView))]
	interface BTUIHorizontalButtonStackSeparatorLineView
	{
		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}
//
//	// @interface BTUIJCBVectorArtView : BTUICardVectorArtView
//	[BaseType (typeof(BTUICardVectorArtView))]
//	interface BTUIJCBVectorArtView
//	{
//	}
//
//	// @interface BTUIMaestroVectorArtView : BTUICardVectorArtView
//	[BaseType (typeof(BTUICardVectorArtView))]
//	interface BTUIMaestroVectorArtView
//	{
//	}
//
//	// @interface BTUIMasterCardVectorArtView : BTUICardVectorArtView
//	[BaseType (typeof(BTUICardVectorArtView))]
//	interface BTUIMasterCardVectorArtView
//	{
//	}
//
//	// @interface BTUIPayPalMonogramCardView : BTUICardVectorArtView
//	[BaseType (typeof(BTUICardVectorArtView))]
//	interface BTUIPayPalMonogramCardView
//	{
//	}
//
//	// @interface BTUI : NSObject
//	[BaseType (typeof(NSObject))]
//	interface BTUI
//	{
//	}

	// @interface BTUIPayPalWordmarkVectorArtView : BTUIVectorArtView
	[BaseType (typeof(BTUIVectorArtView))]
	interface BTUIPayPalWordmarkVectorArtView
	{
		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @interface BTUIPaymentButtonCollectionViewCell : UICollectionViewCell
	[BaseType (typeof(UICollectionViewCell))]
	interface BTUIPaymentButtonCollectionViewCell
	{
		// @property (nonatomic, strong) UIControl * paymentButton;
		[Export ("paymentButton", ArgumentSemantic.Strong)]
		UIControl PaymentButton { get; set; }
	}

	// @protocol BTUIScrollViewScrollRectToVisibleDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTUIScrollViewScrollRectToVisibleDelegate
	{
	}

	// @interface BTUIScrollView : UIScrollView
	[BaseType (typeof(UIScrollView))]
	interface BTUIScrollView
	{
		[Wrap ("WeakScrollRectToVisibleDelegate")]
		BTUIScrollViewScrollRectToVisibleDelegate ScrollRectToVisibleDelegate { get; set; }

		// @property (nonatomic, weak) id<BTUIScrollViewScrollRectToVisibleDelegate> scrollRectToVisibleDelegate;
		[NullAllowed, Export ("scrollRectToVisibleDelegate", ArgumentSemantic.Weak)]
		NSObject WeakScrollRectToVisibleDelegate { get; set; }

		// -(void)defaultScrollRectToVisible:(CGRect)rect animated:(BOOL)animated;
		[Export ("defaultScrollRectToVisible:animated:")]
		void DefaultScrollRectToVisible (CGRect rect, bool animated);
	}

	// @protocol BTUIScrollViewScrollRectToVisibleDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTUIScrollViewScrollRectToVisibleDelegate
	{
		// @required -(void)scrollView:(BTUIScrollView *)scrollView requestsScrollRectToVisible:(CGRect)rect animated:(BOOL)animated;
		[Abstract]
		[Export ("scrollView:requestsScrollRectToVisible:animated:")]
		void RequestsScrollRectToVisible (BTUIScrollView scrollView, CGRect rect, bool animated);
	}

	// @protocol BTUITextFieldEditDelegate <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface BTUITextFieldEditDelegate
//	{
//	}

	// @interface BTUITextField : UITextField
	[BaseType (typeof(UITextField))]
	interface BTUITextField
	{
		[Wrap ("WeakEditDelegate")]
		BTUITextFieldEditDelegate EditDelegate { get; set; }

		// @property (nonatomic, weak) id<BTUITextFieldEditDelegate> editDelegate;
		[NullAllowed, Export ("editDelegate", ArgumentSemantic.Weak)]
		NSObject WeakEditDelegate { get; set; }
	}

	// @protocol BTUITextFieldEditDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTUITextFieldEditDelegate
	{
		// @optional -(void)textFieldWillDeleteBackward:(BTUITextField *)textField;
		[Export ("textFieldWillDeleteBackward:")]
		void TextFieldWillDeleteBackward (BTUITextField textField);

		// @optional -(void)textFieldDidDeleteBackward:(BTUITextField *)textField originalText:(NSString *)originalText;
		[Export ("textFieldDidDeleteBackward:originalText:")]
		void TextFieldDidDeleteBackward (BTUITextField textField, string originalText);

		// @optional -(void)textField:(BTUITextField *)textField willInsertText:(NSString *)text;
		[Export ("textField:willInsertText:")]
		void TextField (BTUITextField textField, string text);

		// @optional -(void)textField:(BTUITextField *)textField didInsertText:(NSString *)text;
		[Export ("textField:didInsertText:")]
		void TextField (BTUITextField textField, string text);
	}

	// @interface BTUIUnknownCardVectorArtView : BTUICardVectorArtView
//	[BaseType (typeof(BTUICardVectorArtView))]
//	interface BTUIUnknownCardVectorArtView
//	{
//	}

	// @interface BTUIUtil : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUIUtil
	{
		// +(BOOL)luhnValid:(NSString *)cardNumber;
		[Static]
		[Export ("luhnValid:")]
		bool LuhnValid (string cardNumber);

		// +(NSString *)stripNonDigits:(NSString *)input;
		[Static]
		[Export ("stripNonDigits:")]
		string StripNonDigits (string input);

		// +(NSString *)stripNonExpiry:(NSString *)input;
		[Static]
		[Export ("stripNonExpiry:")]
		string StripNonExpiry (string input);
	}

	// @interface BTUIVenmoWordmarkVectorArtView : BTUIVectorArtView
	[BaseType (typeof(BTUIVectorArtView))]
	interface BTUIVenmoWordmarkVectorArtView
	{
		// @property (nonatomic, strong) UIColor * color;
		[Export ("color", ArgumentSemantic.Strong)]
		UIColor Color { get; set; }
	}

	// @interface BTUIViewUtil : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUIViewUtil
	{
		// +(BTUIPaymentMethodType)paymentMethodTypeForCardType:(BTUICardType *)cardType;
		[Static]
		[Export ("paymentMethodTypeForCardType:")]
		BTUIPaymentMethodType PaymentMethodTypeForCardType (BTUICardType cardType);

		// +(NSString *)nameForPaymentMethodType:(BTUIPaymentMethodType)paymentMethodType;
		[Static]
		[Export ("nameForPaymentMethodType:")]
		string NameForPaymentMethodType (BTUIPaymentMethodType paymentMethodType);

		// +(void)vibrate;
		[Static]
		[Export ("vibrate")]
		void Vibrate ();
	}

	// @interface BTUIVisaVectorArtView : BTUICardVectorArtView
//	[BaseType (typeof(BTUICardVectorArtView))]
//	interface BTUIVisaVectorArtView
//	{
//	}

	// @interface BTURLUtils : NSObject
	[BaseType (typeof(NSObject))]
	interface BTURLUtils
	{
		// +(NSURL *)URLfromURL:(NSURL *)URL withAppendedQueryDictionary:(NSDictionary *)dictionary;
		[Static]
		[Export ("URLfromURL:withAppendedQueryDictionary:")]
		NSURL URLfromURL (NSURL URL, NSDictionary dictionary);

		// +(NSString *)queryStringWithDictionary:(NSDictionary *)dict;
		[Static]
		[Export ("queryStringWithDictionary:")]
		string QueryStringWithDictionary (NSDictionary dict);

		// +(NSDictionary *)dictionaryForQueryString:(NSString *)queryString;
		[Static]
		[Export ("dictionaryForQueryString:")]
		NSDictionary DictionaryForQueryString (string queryString);
	}

	// @interface BTVenmoAppSwitchHandler : NSObject <BTAppSwitching>
	[BaseType (typeof(NSObject))]
	interface BTVenmoAppSwitchHandler : IBTAppSwitching
	{
		// +(instancetype)sharedHandler;
		[Static]
		[Export ("sharedHandler")]
		BTVenmoAppSwitchHandler SharedHandler ();

		// @property (nonatomic, strong) BTClient * client;
		[Export ("client", ArgumentSemantic.Strong)]
		BTClient Client { get; set; }
	}

	// @interface  (BTVenmoAppSwitchHandler)
	[Category]
	[BaseType (typeof(BTVenmoAppSwitchHandler))]
	interface BTVenmoAppSwitchHandler_
	{
		// @property (nonatomic, strong) BTClient * client;
		[Export ("client")]
		BTClient Client { get; set; }
	}

	// @interface BTVenmoAppSwitchRequestURL : NSObject
	[BaseType (typeof(NSObject))]
	interface BTVenmoAppSwitchRequestURL
	{
		// +(BOOL)isAppSwitchAvailable;
		[Static]
		[Export ("isAppSwitchAvailable")]
		[Verify (MethodToProperty)]
		bool IsAppSwitchAvailable { get; }

		// +(NSURL *)appSwitchURLForMerchantID:(NSString *)merchantID returnURLScheme:(NSString *)scheme offline:(BOOL)offline error:(NSError **)error;
		[Static]
		[Export ("appSwitchURLForMerchantID:returnURLScheme:offline:error:")]
		NSURL AppSwitchURLForMerchantID (string merchantID, string scheme, bool offline, out NSError error);
	}

	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const BTVenmoAppSwitchReturnURLErrorDomain;
		[Field ("BTVenmoAppSwitchReturnURLErrorDomain")]
		NSString BTVenmoAppSwitchReturnURLErrorDomain { get; }
	}

	// @interface BTVenmoAppSwitchReturnURL : NSObject
	[BaseType (typeof(NSObject))]
	interface BTVenmoAppSwitchReturnURL
	{
		// +(BOOL)isValidURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication;
		[Static]
		[Export ("isValidURL:sourceApplication:")]
		bool IsValidURL (NSURL url, string sourceApplication);

		// -(instancetype)initWithURL:(NSURL *)url;
		[Export ("initWithURL:")]
		IntPtr Constructor (NSURL url);

		// @property (readonly, assign, nonatomic) BTVenmoAppSwitchReturnURLState state;
		[Export ("state", ArgumentSemantic.Assign)]
		BTVenmoAppSwitchReturnURLState State { get; }

		// @property (readonly, nonatomic, strong) BTPaymentMethod * paymentMethod;
		[Export ("paymentMethod", ArgumentSemantic.Strong)]
		BTPaymentMethod PaymentMethod { get; }

		// @property (readonly, nonatomic, strong) NSError * error;
		[Export ("error", ArgumentSemantic.Strong)]
		NSError Error { get; }
	}

	// @interface Braintree : NSObject
	[BaseType (typeof(NSObject))]
	interface Braintree
	{
		// +(Braintree *)braintreeWithClientToken:(NSString *)clientToken;
		[Static]
		[Export ("braintreeWithClientToken:")]
		Braintree BraintreeWithClientToken (string clientToken);

		// -(BTDropInViewController *)dropInViewControllerWithDelegate:(id<BTDropInViewControllerDelegate>)delegate;
		[Export ("dropInViewControllerWithDelegate:")]
		BTDropInViewController DropInViewControllerWithDelegate (BTDropInViewControllerDelegate @delegate);

		// -(BTPaymentButton *)paymentButtonWithDelegate:(id<BTPaymentMethodCreationDelegate>)delegate;
		[Export ("paymentButtonWithDelegate:")]
		BTPaymentButton PaymentButtonWithDelegate (BTPaymentMethodCreationDelegate @delegate);

		// -(BTPaymentButton *)paymentButtonWithDelegate:(id<BTPaymentMethodCreationDelegate>)delegate paymentProviderTypes:(NSOrderedSet *)types;
		[Export ("paymentButtonWithDelegate:paymentProviderTypes:")]
		BTPaymentButton PaymentButtonWithDelegate (BTPaymentMethodCreationDelegate @delegate, NSOrderedSet types);

		// -(void)tokenizeCard:(BTClientCardTokenizationRequest *)cardDetails completion:(void (^)(NSString *, NSError *))completionBlock;
		[Export ("tokenizeCard:completion:")]
		void TokenizeCard (BTClientCardTokenizationRequest cardDetails, Action<NSString, NSError> completionBlock);

		// -(BTPaymentProvider *)paymentProviderWithDelegate:(id<BTPaymentMethodCreationDelegate>)delegate;
		[Export ("paymentProviderWithDelegate:")]
		BTPaymentProvider PaymentProviderWithDelegate (BTPaymentMethodCreationDelegate @delegate);

		// +(void)setReturnURLScheme:(NSString *)scheme;
		[Static]
		[Export ("setReturnURLScheme:")]
		void SetReturnURLScheme (string scheme);

		// +(BOOL)handleOpenURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication;
		[Static]
		[Export ("handleOpenURL:sourceApplication:")]
		bool HandleOpenURL (NSURL url, string sourceApplication);

		// @property (readonly, nonatomic) BTClient * client;
		[Export ("client")]
		BTClient Client { get; }

		// +(NSString *)libraryVersion;
		[Static]
		[Export ("libraryVersion")]
		[Verify (MethodToProperty)]
		string LibraryVersion { get; }

		// @property (nonatomic, strong) BTPayPalButton * payPalButton;
		[Export ("payPalButton", ArgumentSemantic.Strong)]
		BTPayPalButton PayPalButton { get; set; }
	}

	// @interface  (Braintree)
	[Category]
	[BaseType (typeof(Braintree))]
	interface Braintree_
	{
		// @property (nonatomic, strong) BTPayPalButton * payPalButton;
		[Export ("payPalButton")]
		BTPayPalButton PayPalButton { get; set; }
	}

	// @interface BTUI (UIColor)
	[Category]
	[BaseType (typeof(UIColor))]
	interface UIColor_BTUI
	{
		// +(instancetype)bt_colorWithBytesR:(NSInteger)r G:(NSInteger)g B:(NSInteger)b A:(NSInteger)a;
		[Static]
		[Export ("bt_colorWithBytesR:G:B:A:")]
		UIColor Bt_colorWithBytesR (nint r, nint g, nint b, nint a);

		// +(instancetype)bt_colorWithBytesR:(NSInteger)r G:(NSInteger)g B:(NSInteger)b;
		[Static]
		[Export ("bt_colorWithBytesR:G:B:")]
		UIColor Bt_colorWithBytesR (nint r, nint g, nint b);

		// +(instancetype)bt_colorFromHex:(NSString *)hex alpha:(CGFloat)alpha;
		[Static]
		[Export ("bt_colorFromHex:alpha:")]
		UIColor Bt_colorFromHex (string hex, nfloat alpha);

		// -(instancetype)bt_adjustedBrightness:(CGFloat)adjustment;
		[Export ("bt_adjustedBrightness:")]
		UIColor Bt_adjustedBrightness (nfloat adjustment);
	}
}

