using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Infrastructure
{
    public class SingletonFormProvider
    {
        static Dictionary<Type, BaseForm> mTypeFormLookup = new Dictionary<Type, BaseForm>();

        static public T GetInstance<T>()
            where T : BaseForm
        {
            return GetInstanceWithArgs<T>(null);
        }

        static public T GetInstanceWithArgs<T>(params object[] args)
            where T : BaseForm
        {
            if (!mTypeFormLookup.ContainsKey(typeof(T)))
            {
                BaseForm f = (BaseForm)Activator.CreateInstance(typeof(T), args);
                mTypeFormLookup.Add(typeof(T), f);
                f.FormClosed += new FormClosedEventHandler(remover);
            }
            return (T)mTypeFormLookup[typeof(T)];
        }

        static void remover(object sender, FormClosedEventArgs e)
        {
            Form f = sender as Form;
            if (f == null) return;

            f.FormClosed -= new FormClosedEventHandler(remover);
            mTypeFormLookup.Remove(f.GetType());
        }

    }
}
