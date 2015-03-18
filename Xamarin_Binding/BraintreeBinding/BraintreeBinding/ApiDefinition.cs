using System;
using System.Drawing;

using ObjCRuntime;
using Foundation;
using UIKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BraintreeBinding
{
	[BaseType (typeof(NSObject))]
	interface Braintree
	{
		[Static, Export ("braintreeWithClientToken:")]
		Braintree BraintreeWithClientToken (string clientToken);

		[Export ("dropInViewControllerWithDelegate:")]
		BTDropInViewController DropInViewControllerWithDelegate (BTDropInViewControllerDelegate dropInDelegate);

		[Export ("tokenizeCard:completion:")]
		[Async]
		void TokenizeCard (BTClientCardTokenizationRequest cardDetails, Action<string> completed);
	}

	[BaseType (typeof (UIViewController))]
	interface BTDropInViewController
	{
		[Wrap ("WeakDelegate")]
		BTDropInViewControllerDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		[Export ("summaryTitle")]
		string SummaryTitle { get; set; }

		[Export ("summaryDescription")]
		string SummaryDescription { get; set; }

		[Export ("displayAmount")]
		string DisplayAmount { get; set; }

		[Export ("callToActionText")]
		string CallToActionText { get; set; }

		[Export ("shouldHideCallToAction")]
		bool ShouldHideCallToAction { get; set; }

		[Export ("paymentMethods")]
		BTPaymentMethod[] PaymentMethods { get; set; }

		[Export ("fetchPaymentMethods")]
		void FetchPaymentMethods ();
	}

	[Model, Protocol, BaseType (typeof (NSObject))]
	interface BTDropInViewControllerDelegate
	{
		[Abstract, Export ("dropInViewController:didSucceedWithPaymentMethod:")]
		void OnSuccess (BTDropInViewController controller, BTPaymentMethod paymentMethod);

		[Abstract, Export ("dropInViewControllerDidCancel:")]
		void OnCanceled (BTDropInViewController controller);
	}

	[BaseType (typeof (NSObject))]
	interface BTPaymentMethod
	{
		[Export ("nonce")]
		string Nonce { get; }
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
}

