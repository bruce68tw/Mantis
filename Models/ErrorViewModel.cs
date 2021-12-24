using Base.Services;
using System;

namespace Mantis.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !_Str.IsEmpty(RequestId);
    }
}
