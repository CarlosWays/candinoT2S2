using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace candinoT2S2.Behaviors
{
    public class EntradaSinPunto : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            if (!string.IsNullOrEmpty(e.NewTextValue) && e.NewTextValue.Contains("."))
            {
                // Si el texto contiene un punto, revertir al valor anterior
                entry.Text = e.OldTextValue;
            }
        }
    }
}
