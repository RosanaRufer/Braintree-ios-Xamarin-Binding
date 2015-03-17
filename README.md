# Braintree-ios-Xamarin-Binding
Trying to bind Braintree-ios library to Xamarin. It currently works on *simulator* but it doesn't work on a physical device :(

This project contains: 
* The Xcode static library project containing the Braintree library code.
* A make file to build that library for all architectures into a libBraintreeSDK.a file
* The .a resulted from executing that make file
* The Xamarin iOS binding library 
* A simple app using the Xamarin binding library contained in the same solution as the binding liblrary.

###SIMULATOR
![image](https://cloud.githubusercontent.com/assets/4906291/6689385/1490b93e-ccba-11e4-8775-e90568e19094.png)

###IPHONE 5 ARMv7
![image](https://cloud.githubusercontent.com/assets/4906291/6689541/079383a0-ccbb-11e4-8f62-4115b17acc9d.png)


## Make file content used to build the library targets all architectures
XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=.
PROJECT=$(PROJECT_ROOT)/Braintree.xcodeproj
TARGET=Braintree

all: libBraintreeSDK.a

libBraintree-i386.a:
$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build 
-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libBraintree-armv7.a:
$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build 
-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libBraintree-armv7s.a:
$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration Release clean build 
-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libBraintree-arm64.a:
$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build 
-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libBraintreeSDK.a: libBraintree-i386.a libBraintree-armv7.a libBraintree-armv7s.a libBraintree-arm64.a
lipo -create -output $@ $^

clean: -rm -f *.a *.dll
