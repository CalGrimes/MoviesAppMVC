using System;
namespace MovieAppMVC.Models
{
    public class NavLink
    {
        public string Text { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool IsActive { get; set; }

        public NavLink(string text, string action, string controller, string area = null)
        {
            Text = text;
            Area = area;
            Controller = controller;
            Action = action;
        }
    }
}

