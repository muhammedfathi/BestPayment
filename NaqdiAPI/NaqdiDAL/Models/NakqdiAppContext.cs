using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaqdiDAL.Models
{
    public class NakqdiAppContext : DbContext
    {


        public NakqdiAppContext(DbContextOptions<NakqdiAppContext> options) : base(options)
        {
        }

        // public virtual DbSet<Mohamedkhaled> Mohamedk{ get; set; }
        
        public virtual DbSet<Banks> Banks { get; set; }
        public virtual DbSet<cases> cases { get; set; }
        public virtual DbSet<CasesCPS> CasesCPS { get; set; }
        public virtual DbSet<CasesCPSField_Prov> CasesCPSField_Provs { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Complaint> Complaint { get; set; }
        public virtual DbSet<Excute> Excute { get; set; }
        public virtual DbSet<Execution_Response> Execution_Responses { get; set; }
        public virtual DbSet<GlobalConfigration> GlobalConfigration { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<PayMent_Cards> PayMent_Cards { get; set; }
        public virtual DbSet<privilage> privilage { get; set; }
        public virtual DbSet<Reply> Reply { get; set; }
        public virtual DbSet<Rol_PrivFT> Rol_PrivFT { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<TUser> TUser { get; set; }
        public virtual DbSet<ChargeOperation> ChargeOperations { get; set; }
        public virtual DbSet<ChargeSim> ChargeSims { get; set; }
        public virtual DbSet<Login_Information> Login_Information { get; set; }
        public virtual DbSet<AgentCommissions> AgentCommissions { get; set; }
        public virtual DbSet<UsersDeposit> UsersDeposit { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<ProvidersDeposit> ProvidersDeposits { get; set; }
        public virtual DbSet<Service_Provider> Service_Providers { get; set; }
        public virtual DbSet<Fields_Mapping> Fields_Mappings  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersDeposit>().HasOne(m => m.User).WithMany(m => m.UsersDeposit).HasForeignKey(m => m.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsersDeposit>().HasOne(m => m.User1).WithMany(m => m.UsersDeposit1).HasForeignKey(m => m.ResposibleID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsersDeposit>().HasOne(m => m.User2).WithMany(m => m.UsersDeposit2).HasForeignKey(m => m.ToUser).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Excute>().HasOne(m => m.TUser).WithMany(m => m.Excute).HasForeignKey(m => m.user_id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Excute>().HasOne(m => m.TUser1).WithMany(m => m.Excute1).HasForeignKey(m => m.FinalUser).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>().HasData(
                new Role { ID =1, name = "مالك"},
                new Role { ID =2, name = "وكيل"},
                new Role { ID =3, name = "مركز"},
                new Role { ID =4, name = "موظف"}
                );
       
        }


        //public virtual DbSet<Company_ProviderFT> Company_ProviderFT { get; set; }
        //public virtual DbSet<CPService> CPService { get; set; }
        //public virtual DbSet<Menu> Menu { get; set; }
        //public virtual DbSet<Field> Field { get; set; }
        //public virtual DbSet<FieldDropDownListValues> FieldDropDownListValues { get; set; }

        //public virtual DbSet<ServiceFieldsFT> ServiceFieldsFT { get; set; }
        //public virtual DbSet<Static_Services> Static_Services { get; set; }
        //public virtual DbSet<UsersGroup> UsersGroup { get; set; }
        //public virtual DbSet<Safe> Safe { get; set; }
        //public virtual DbSet<ProvidersDeposit> ProvidersDeposit { get; set; }

    }
}
