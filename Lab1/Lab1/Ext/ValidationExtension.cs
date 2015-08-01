using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Validator.Engine;

namespace Lab1
{
    public static class ValidationExtension
    {
        public static void Validate(this Controller controller, object Entity)
        {
            ValidatorEngine vtor = NHibernate.Validator.Cfg.Environment.SharedEngineProvider.GetEngine();
            InvalidValue[] errors = vtor.Validate(Entity);
            foreach (InvalidValue error in errors)
            {
                controller.ModelState.AddModelError(error.PropertyName, error.Message);
            }
        }
    }
}