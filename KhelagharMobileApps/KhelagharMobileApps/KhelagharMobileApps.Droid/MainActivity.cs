﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DryIoc;
using Prism.DryIoc;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace KhelagharMobileApps.Droid
{
  [Activity(Label = "KhelagharMobileApps", Icon = "@drawable/icon", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    protected override void OnCreate(Bundle bundle)
    {
      TabLayoutResource = Resource.Layout.tabs;
      ToolbarResource = Resource.Layout.toolbar;

      base.OnCreate(bundle);

      UserDialogs.Init(() => (Activity)Forms.Context);

      global::Xamarin.Forms.Forms.Init(this, bundle);
      Xamarin.FormsMaps.Init(this, bundle);
      LoadApplication(new App(new AndroidInitializer()));
    }
  }

  public class AndroidInitializer : IPlatformInitializer
  {
    public void RegisterTypes(IContainer container)
    {

    }
  }
}

