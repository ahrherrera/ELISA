﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ELISA
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class elisaEntities2 : DbContext
    {
        public elisaEntities2()
            : base("name=elisaEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<anti_human_igg> anti_human_igg { get; set; }
        public DbSet<anti_human_igm> anti_human_igm { get; set; }
        public DbSet<antigeno_viral> antigeno_viral { get; set; }
        public DbSet<chikungunyainhhiper> chikungunyainhhipers { get; set; }
        public DbSet<chikungunyainhmono> chikungunyainhmonoes { get; set; }
        public DbSet<componentesns1> componentesns1 { get; set; }
        public DbSet<componentesrotaviru> componentesrotavirus { get; set; }
        public DbSet<componentesvih> componentesvihs { get; set; }
        public DbSet<conjugado> conjugadoes { get; set; }
        public DbSet<controles_ns1> controles_ns1 { get; set; }
        public DbSet<controles_rotaviru> controles_rotavirus { get; set; }
        public DbSet<controles_vih> controles_vihs { get; set; }
        public DbSet<controles_ei> controles_ei { get; set; }
        public DbSet<controles_igg> controles_igg { get; set; }
        public DbSet<controles_igm> controles_igm { get; set; }
        public DbSet<datosprotocoloei> datosprotocoloeis { get; set; }
        public DbSet<datosprotocoloigm> datosprotocoloigms { get; set; }
        public DbSet<datosprotocolons1> datosprotocolons1 { get; set; }
        public DbSet<datosprotocolorotaviru> datosprotocolorotavirus { get; set; }
        public DbSet<datosprotocolovih> datosprotocolovihs { get; set; }
        public DbSet<elisaigg> elisaiggs { get; set; }
        public DbSet<elisaiggrepeticione> elisaiggrepeticiones { get; set; }
        public DbSet<elisaigm> elisaigms { get; set; }
        public DbSet<elisainh> elisainhs { get; set; }
        public DbSet<elisainh1d> elisainh1d { get; set; }
        public DbSet<elisainh1dchik> elisainh1dchik { get; set; }
        public DbSet<elisainh1dchikrepeticiones> elisainh1dchikrepeticiones { get; set; }
        public DbSet<elisainh1dchiksero> elisainh1dchiksero { get; set; }
        public DbSet<elisainh1dchikserorepeticiones> elisainh1dchikserorepeticiones { get; set; }
        public DbSet<elisainh1drepeticiones> elisainh1drepeticiones { get; set; }
        public DbSet<elisainhrm> elisainhrms { get; set; }
        public DbSet<elisainhrmchik> elisainhrmchiks { get; set; }
        public DbSet<elisainhrmchikrepeticione> elisainhrmchikrepeticiones { get; set; }
        public DbSet<elisainhrmchiksero> elisainhrmchikseroes { get; set; }
        public DbSet<elisainhrmchikserorepeticione> elisainhrmchikserorepeticiones { get; set; }
        public DbSet<elisainhrmrepeticione> elisainhrmrepeticiones { get; set; }
        public DbSet<elisainhtmp> elisainhtmps { get; set; }
        public DbSet<elisainhzika> elisainhzikas { get; set; }
        public DbSet<ensayo> ensayos { get; set; }
        public DbSet<estudio> estudios { get; set; }
        public DbSet<gammaglobulina> gammaglobulinas { get; set; }
        public DbSet<kit_elisa_ns1> kit_elisa_ns1 { get; set; }
        public DbSet<kit_elisa_rotaviru> kit_elisa_rotavirus { get; set; }
        public DbSet<kit_elisa_vih> kit_elisa_vihs { get; set; }
        public DbSet<laboratorista> laboratoristas { get; set; }
        public DbSet<ns1> ns1 { get; set; }
        public DbSet<pbs1x> pbs1x { get; set; }
        public DbSet<pbs20x> pbs20x { get; set; }
        public DbSet<ph_9_6__coatting_> ph_9_6__coatting_ { get; set; }
        public DbSet<proch20> proch20 { get; set; }
        public DbSet<reactivos_ns1> reactivos_ns1 { get; set; }
        public DbSet<reactivos_rotaviru> reactivos_rotavirus { get; set; }
        public DbSet<reactivos_vih> reactivos_vihs { get; set; }
        public DbSet<reactivos_bei> reactivos_bei { get; set; }
        public DbSet<reactivos_bob> reactivos_bob { get; set; }
        public DbSet<rotaviru> rotavirus { get; set; }
        public DbSet<shn> shns { get; set; }
        public DbSet<substrato> substratoes { get; set; }
        public DbSet<tipo_control> tipo_control { get; set; }
        public DbSet<tipobloqueo> tipobloqueos { get; set; }
        public DbSet<tipodiluyente> tipodiluyentes { get; set; }
        public DbSet<usuario> usuarios { get; set; }
        public DbSet<vih> vihs { get; set; }
        public DbSet<zika1d> zika1d { get; set; }
        public DbSet<zika1ddup> zika1ddup { get; set; }
        public DbSet<zikabob> zikabobs { get; set; }
        public DbSet<zikabobanual> zikabobanuals { get; set; }
        public DbSet<zikabobanualdup> zikabobanualdups { get; set; }
        public DbSet<zikaigm> zikaigms { get; set; }
        public DbSet<zikaigmbei> zikaigmbeis { get; set; }
        public DbSet<zikarmanual> zikarmanuals { get; set; }
        public DbSet<zikarmanualdup> zikarmanualdups { get; set; }
        public DbSet<datosprotocolochik> datosprotocolochiks { get; set; }
        public DbSet<datosprotocolochikhiper> datosprotocolochikhipers { get; set; }
        public DbSet<datosprotocolochikmono> datosprotocolochikmonoes { get; set; }
        public DbSet<datosprotocoloeiensayo> datosprotocoloeiensayos { get; set; }
        public DbSet<datosprotocoloeizika> datosprotocoloeizikas { get; set; }
        public DbSet<datosprotocoloigg> datosprotocoloiggs { get; set; }
        public DbSet<datosprotocoloigmzika> datosprotocoloigmzikas { get; set; }
        public DbSet<datosprotocolozikabob> datosprotocolozikabobs { get; set; }
        public DbSet<datosprotocolozikaigmbei> datosprotocolozikaigmbeis { get; set; }
        public DbSet<chikungunya> chikungunyas { get; set; }
    }
}
