﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirtualMuseum.Application.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ErrorMessage {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessage() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VirtualMuseum.Application.Resources.ErrorMessage", typeof(ErrorMessage).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Статья уже существует.
        /// </summary>
        internal static string ArticleAlreadyExists {
            get {
                return ResourceManager.GetString("ArticleAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Статья не найдена.
        /// </summary>
        internal static string ArticleNotFount {
            get {
                return ResourceManager.GetString("ArticleNotFount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Автор не найден.
        /// </summary>
        internal static string AutorNotFount {
            get {
                return ResourceManager.GetString("AutorNotFount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Внутрянняя ошибка сервера.
        /// </summary>
        internal static string InternalServerError {
            get {
                return ResourceManager.GetString("InternalServerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Невалидный запрос клиента.
        /// </summary>
        internal static string InvalidClientRequest {
            get {
                return ResourceManager.GetString("InvalidClientRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Неверный пароль.
        /// </summary>
        internal static string InvalidPassword {
            get {
                return ResourceManager.GetString("InvalidPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Неверный токен.
        /// </summary>
        internal static string InvalidToken {
            get {
                return ResourceManager.GetString("InvalidToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Подтема не найдена.
        /// </summary>
        internal static string SubToticNotFount {
            get {
                return ResourceManager.GetString("SubToticNotFount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Пользователь уже существует.
        /// </summary>
        internal static string UserAlreadyExists {
            get {
                return ResourceManager.GetString("UserAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Пользователь не найден.
        /// </summary>
        internal static string UserNotFount {
            get {
                return ResourceManager.GetString("UserNotFount", resourceCulture);
            }
        }
    }
}
