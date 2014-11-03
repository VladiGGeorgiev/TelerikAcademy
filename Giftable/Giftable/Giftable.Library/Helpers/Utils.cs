using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Giftable.Library.Helpers
{
    public static class Utils
    {
        /// <summary> 
        /// Recursive get the item. 
        /// </summary> 
        /// <typeparam name="T">The item to get.</typeparam> 
        /// <param name="parents">Parent container.</param> 
        /// <param name="objectList">Item list</param> 
        public static void GetItemsRecursive<T>(DependencyObject parents, ref List<T> objectList) where T : DependencyObject
        {
            var childrenCount = VisualTreeHelper.GetChildrenCount(parents);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parents, i);
                if (child is T)
                {
                    objectList.Add(child as T);
                }
                GetItemsRecursive<T>(child, ref objectList);
            }
        } 
    }
}
