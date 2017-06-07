using GerenciadorDeProjetos.Module.BusinessObjects.ClassUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace GerenciadorDeProjetos.Module.BusinessObjects.Shared
{
    [NonPersistent]
    public abstract class SequencialObject : Sequencial
    {
        private int _codigo;

        public SequencialObject(Session session) : base(session)
        {
        }

        #region Rules
        [Appearance("Esconde Campo Codigo em Modo Criação", Criteria = "IsNewObject", Visibility = ViewItemVisibility.Hide)]
        //[Appearance("Desabilita Campo Codigo em Modo Edição", Criteria = "!IsNewObject", Context = "DetailView", Enabled = false)]
        [PersistentAlias("SequentialNumber")]
        #endregion
        public int Codigo
        {
            get
            {
                return Convert.ToInt32(EvaluateAlias("Codigo"));
            }

            set
            {
                SetPropertyValue("Codigo", ref _codigo, value);
            }
        }

        protected override void OnSaving()
        {
            GerarCodigo();
            base.OnSaving();
        }
        public void GerarCodigo()
        {
            try
            {
                if (Session.IsNewObject(this) && !typeof(NestedUnitOfWork).IsInstanceOfType(Session))
                {
                    GenerateSequence();
                }
            }
            catch (Exception)
            {
                CancelSequence();
                throw;
            }
        }
    }
}
