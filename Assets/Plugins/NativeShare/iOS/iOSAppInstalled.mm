//
//  AppDelegate.h
//  UnityAppInstalled
//
//  Created by SongSinh on 6/13/19.
//  Copyright © 2019 SongSinh. All rights reserved.
//
// Credit: https://github.com/songsinh88/UnityAppInstalled.git

#import <UIKit/UIKit.h>

extern "C" bool _Check_App_Installed( char* bundleID )
{
    return [[UIApplication sharedApplication] canOpenURL:[NSURL URLWithString:[NSString stringWithUTF8String:bundleID]]];
}
