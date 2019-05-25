using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DocumentReader.Utils
{
    enum DialogType
    {
        LOADING,
        NOTIFICATION,
        WARNING,
        ERROR,
    }

    class DialogMessage
    {
        public DialogType id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string negativeButtonTitle { get; set; }
        public string positiveButtonTitle { get; set; }
        public Visibility displayNegativeButton { get; set; }
    }

    class DialogHelper
    {
        private static DialogSession currentSession = null;

        public static void show(string msg = "", string title = "", string positiveButtonTitle = "Ok", string negativeButtonTitle = "Cancel", bool displayNegativeButton = false, DialogType type = DialogType.NOTIFICATION, Action<bool> action = null)
        {

            if (currentSession != null)
            {
                try
                {
                    var content = (DialogMessage)currentSession.Content;
                    if (content.id == DialogType.LOADING)
                    {
                        dismiss();
                    }
                }
                catch (Exception ex)
                {

                }
            }


            DialogType tempType = type == DialogType.LOADING ? type : DialogType.NOTIFICATION;
            string typeName = Enum.GetName(typeof(DialogType), tempType);
            string dialogIdentifier = typeName.First().ToString() + typeName.Substring(1).ToLower() + "Dialog";

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    DialogHost.Show(new DialogMessage
                    {
                        id = tempType,
                        title = type == DialogType.ERROR ? "Error" : title,
                        message = msg,
                        negativeButtonTitle = negativeButtonTitle,
                        positiveButtonTitle = positiveButtonTitle,
                        displayNegativeButton = (negativeButtonTitle != "Cancel" || displayNegativeButton) ? Visibility.Visible : Visibility.Collapsed,
                    },
                    dialogIdentifier,
                    new DialogOpenedEventHandler((object sender, DialogOpenedEventArgs args) =>
                    {
                        DialogSession session = args.Session;
                        currentSession = args.Session;
                        //Updating the contents of the dialog
                        //object newContent = ...;
                        //session.UpdateContent(newContent);

                        //Closing dialog programmatically. Pass the session object to where it is needed.
                        //session.Close();
                    }),
                    new DialogClosingEventHandler((object sender, DialogClosingEventArgs args) =>
                    {
                        DialogSession session = args.Session;
                        currentSession = null;
                        if (args.Parameter != null)
                        {
                            action?.Invoke(!(bool)args.Parameter);
                        }
                    })
                )));

        }

        public static void dismiss()
        {
            Application.Current.Dispatcher.BeginInvoke((Action)delegate {
                if (currentSession != null)
                    currentSession.Close();
            });
        }

        public static async void showCreateSoldier(UserControl view, Action<bool> action = null)
        {
            await DialogHost.Show(view, "RootDialog",
                    new DialogOpenedEventHandler((object sender, DialogOpenedEventArgs args) =>
                    {
                        DialogSession session = args.Session;
                        currentSession = args.Session;
                        //Updating the contents of the dialog
                        //object newContent = ...;
                        //session.UpdateContent(newContent);

                        //Closing dialog programmatically. Pass the session object to where it is needed.
                        //session.Close();
                    }),
                    new DialogClosingEventHandler((object sender, DialogClosingEventArgs args) =>
                    {
                        DialogSession session = args.Session;
                        currentSession = null;
                        if (args.Parameter != null)
                        {
                            action?.Invoke(!(bool)args.Parameter);
                        }
                    }));
        }
    }
}
