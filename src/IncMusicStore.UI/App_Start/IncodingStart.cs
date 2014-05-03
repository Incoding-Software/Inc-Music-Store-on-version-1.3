using System;

[assembly: WebActivator.PreApplicationStartMethod(
    typeof(IncMusicStore.UI.App_Start.IncodingStart), "PreStart")]

namespace IncMusicStore.UI.App_Start {
    using IncMusicStore.Domain;
    using IncMusicStore.UI.Controllers;

    public static class IncodingStart {
        public static void PreStart() {
            Bootstrapper.Start();
            new DispatcherController(); // init routes
        }
    }
}