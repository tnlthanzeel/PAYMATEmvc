using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enumarations
{
    public enum ErrorMessagesEnum
    {
        [Description("This Email Address is already taken.")]
        EmailAlreadyTaken
    }
}
