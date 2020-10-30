using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WindowsFormsApplication1
{

    public sealed class CodeActivity1 : CodeActivity
    {
        // Définir un argument d'entrée d'activité de type string
        public InArgument<string> Text { get; set; }

        // Si votre activité retourne une valeur, dérivez de CodeActivity<TResult>
        // et retournez la valeur à partir de la méthode Execute.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtenir la valeur runtime de l'argument d'entrée Text
            string text = context.GetValue(this.Text);
        }
    }
}
