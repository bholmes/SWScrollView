XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=.
PROJECT=$(PROJECT_ROOT)/SWScrollView.xcodeproj
TARGET=SWScrollView

all: libSWScrollViewSDK.a

libSWScrollView-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libSWScrollView-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libSWScrollViewSDK.a: libSWScrollView-i386.a libSWScrollView-armv7.a
	lipo -create -output $@ $^

clean:
	-rm -f *.a *.dll
