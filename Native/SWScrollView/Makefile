XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=.
PROJECT=$(PROJECT_ROOT)/SWScrollView.xcodeproj
TARGET=SWScrollView

all: libSWScrollViewSDK.a SWScrollView.nib

libSWScrollView-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libSWScrollView-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

SWScrollView.nib:
	ibtool --errors --warnings --notices --output-format human-readable-text --compile SWScrollView.nib ../../Externals/SWScrollView/SWScrollView/Classes/SWScrollView.xib --sdk "/Applications/Xcode.app/Contents/Developer/Platforms/iPhoneSimulator.platform/Developer/SDKs/iPhoneSimulator6.1.sdk/"


libSWScrollViewSDK.a: libSWScrollView-i386.a libSWScrollView-armv7.a
	lipo -create -output $@ $^

clean:
	-rm -f *.a *.dll *.nib
