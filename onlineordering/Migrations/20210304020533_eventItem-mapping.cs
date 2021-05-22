// Decompiled with JetBrains decompiler
// Type: TGBS.Website.Migrations.eventItemmapping
// Assembly: TGBS.Website, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D7D76B22-FCDE-4A7C-B6A7-8F3B12BD39F5
// Assembly location: C:\Users\Taylor\Downloads\wwwroot (1)\TGBS.Website.dll

using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TGBS.Website.Migrations
{
  [DbContext(typeof (PizzaStoreContext))]
  [Migration("20210304020533_eventItem-mapping")]
  public class eventItemmapping : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey("FK_SpecialEventCategories_Specials_PizzaSpecialId", "SpecialEventCategories");
      migrationBuilder.DropIndex("IX_SpecialEventCategories_PizzaSpecialId", "SpecialEventCategories");
      migrationBuilder.DropColumn("PizzaSpecialId", "SpecialEventCategories");
    }

    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("ProductVersion", (object) "3.1.8");
      modelBuilder.Entity("BlazingPizza.Drink", (Action<EntityTypeBuilder>) (b =>
      {
        b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType<int>("INTEGER");
        b.Property<string>("DrinkName").HasColumnType<string>("TEXT");
        b.Property<string>("ImageUrl").HasColumnType<string>("TEXT");
        b.Property<Decimal>("Price").HasColumnType<Decimal>("TEXT");
        b.Property<string>("ReportingCategory").HasColumnType<string>("TEXT");
        b.HasKey("Id");
        b.ToTable("Drinks");
      }));
      modelBuilder.Entity("BlazingPizza.DrinkOrderItem", (Action<EntityTypeBuilder>) (b =>
      {
        b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType<int>("INTEGER");
        b.Property<int>("DrinkId").HasColumnType<int>("INTEGER");
        b.Property<int>("OrderId").HasColumnType<int>("INTEGER");
        b.HasKey("Id");
        b.HasIndex("DrinkId");
        b.HasIndex("OrderId");
        b.ToTable("DrinkItems");
      }));
      modelBuilder.Entity("BlazingPizza.NotificationSubscription", (Action<EntityTypeBuilder>) (b =>
      {
        b.Property<int>("NotificationSubscriptionId").ValueGeneratedOnAdd().HasColumnType<int>("INTEGER");
        b.Property<string>("Auth").HasColumnType<string>("TEXT");
        b.Property<string>("P256dh").HasColumnType<string>("TEXT");
        b.Property<string>("Url").HasColumnType<string>("TEXT");
        b.Property<string>("UserId").HasColumnType<string>("TEXT");
        b.HasKey("NotificationSubscriptionId");
        b.ToTable("NotificationSubscriptions");
      }));
      modelBuilder.Entity("BlazingPizza.Order", (Action<EntityTypeBuilder>) (b =>
      {
        b.Property<int>("OrderId").ValueGeneratedOnAdd().HasColumnType<int>("INTEGER");
        b.Property<DateTime>("CollectionDate").HasColumnType<DateTime>("TEXT");
        b.Property<string>("Comment").HasColumnType<string>("TEXT");
        b.Property<DateTime>("CreatedTime").HasColumnType<DateTime>("TEXT");
        b.Property<string>("Name").IsRequired(true).HasColumnType<string>("TEXT");
        b.Property<string>("Number").IsRequired(true).HasColumnType<string>("TEXT");
        b.Property<string>("Password").HasColumnType<string>("TEXT");
        b.Property<string>("Status").HasColumnType<string>("TEXT");
        b.Property<string>("UserId").HasColumnType<string>("TEXT");
        b.HasKey("OrderId");
        b.ToTable("Orders");
      }));
      modelBuilder.Entity("BlazingPizza.Pizza", (Action<EntityTypeBuilder>) (b =>
      {
        b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType<int>("INTEGER");
        b.Property<bool>("GlutenFree").HasColumnType<bool>("INTEGER");
        b.Property<int>("OrderId").HasColumnType<int>("INTEGER");
        b.Property<int>("Size").HasColumnType<int>("INTEGER");
        b.Property<int>("SpecialId").HasColumnType<int>("INTEGER");
        b.Property<bool>("Vegan").HasColumnType<bool>("INTEGER");
        b.HasKey("Id");
        b.HasIndex("OrderId");
        b.HasIndex("SpecialId");
        b.ToTable("Pizzas");
      }));
      modelBuilder.Entity("BlazingPizza.PizzaSpecial", (Action<EntityTypeBuilder>) (b =>
      {
        b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType<int>("INTEGER");
        b.Property<Decimal>("BasePrice").HasColumnType<Decimal>("TEXT");
        b.Property<bool>("CanBeTwelveInch").HasColumnType<bool>("INTEGER");
        b.Property<bool>("CanBeVegan").HasColumnType<bool>("INTEGER");
        b.Property<string>("Category").HasColumnType<string>("TEXT");
        b.Property<string>("Description").HasColumnType<string>("TEXT");
        b.Property<Decimal>("EightInchPrice").HasColumnType<Decimal>("TEXT");
        b.Property<string>("ImageUrl").HasColumnType<string>("TEXT");
        b.Property<bool>("IsEnabled").HasColumnType<bool>("INTEGER");
        b.Property<bool>("IsEventItem").HasColumnType<bool>("INTEGER");
        b.Property<bool>("IsSide").HasColumnType<bool>("INTEGER");
        b.Property<string>("Name").HasColumnType<string>("TEXT");
        b.Property<bool>("RestrictedItem").HasColumnType<bool>("INTEGER");
        b.Property<int>("StockCount").HasColumnType<int>("INTEGER");
        b.Property<Decimal>("TwelveInchPrice").HasColumnType<Decimal>("TEXT");
        b.HasKey("Id");
        b.ToTable("Specials");
      }));
      modelBuilder.Entity("BlazingPizza.PizzaTopping", (Action<EntityTypeBuilder>) (b =>
      {
        b.Property<int>("PizzaId").HasColumnType<int>("INTEGER");
        b.Property<int>("ToppingId").HasColumnType<int>("INTEGER");
        b.HasKey("PizzaId", "ToppingId");
        b.HasIndex("ToppingId");
        b.ToTable("PizzaTopping");
      }));
      modelBuilder.Entity("BlazingPizza.SpecialEventCategory", (Action<EntityTypeBuilder>) (b =>
      {
        b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType<Guid>("TEXT");
        b.Property<string>("CategoryName").HasColumnType<string>("TEXT");
        b.Property<string>("EndTime").HasColumnType<string>("TEXT");
        b.Property<DateTime>("EventDate").HasColumnType<DateTime>("TEXT");
        b.Property<int>("FreeDeliveryThreshold").HasColumnType<int>("INTEGER");
        b.Property<string>("LimitedPostcodePrepends").HasColumnType<string>("TEXT");
        b.Property<int?>("PizzaSpecialId").HasColumnType<int?>("INTEGER");
        b.Property<DateTime>("PreorderByDate").HasColumnType<DateTime>("TEXT");
        b.Property<string>("StartTime").HasColumnType<string>("TEXT");
        b.Property<int>("TimeslotInterval").HasColumnType<int>("INTEGER");
        b.HasKey("Id");
        b.HasIndex("PizzaSpecialId");
        b.ToTable("SpecialEventCategories");
      }));
      modelBuilder.Entity("BlazingPizza.Topping", (Action<EntityTypeBuilder>) (b =>
      {
        b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType<int>("INTEGER");
        b.Property<string>("Name").HasColumnType<string>("TEXT");
        b.Property<Decimal>("Price").HasColumnType<Decimal>("TEXT");
        b.HasKey("Id");
        b.ToTable("Toppings");
      }));
      modelBuilder.Entity("TKGroup.Settings.Setting", (Action<EntityTypeBuilder>) (b =>
      {
        b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType<int>("INTEGER");
        b.Property<string>("Description").HasColumnType<string>("TEXT");
        b.Property<string>("Key").HasColumnType<string>("TEXT");
        b.Property<string>("Value").HasColumnType<string>("TEXT");
        b.HasKey("Id");
        b.ToTable("Settings");
      }));
      modelBuilder.Entity("BlazingPizza.DrinkOrderItem", (Action<EntityTypeBuilder>) (b =>
      {
        b.HasOne("BlazingPizza.Drink", "Drink").WithMany().HasForeignKey("DrinkId").OnDelete(DeleteBehavior.Cascade).IsRequired();
        b.HasOne("BlazingPizza.Order", (string) null).WithMany("Drinks").HasForeignKey("OrderId").OnDelete(DeleteBehavior.Cascade).IsRequired();
      }));
      modelBuilder.Entity("BlazingPizza.Pizza", (Action<EntityTypeBuilder>) (b =>
      {
        b.HasOne("BlazingPizza.Order", (string) null).WithMany("Pizzas").HasForeignKey("OrderId").OnDelete(DeleteBehavior.Cascade).IsRequired();
        b.HasOne("BlazingPizza.PizzaSpecial", "Special").WithMany().HasForeignKey("SpecialId").OnDelete(DeleteBehavior.Cascade).IsRequired();
      }));
      modelBuilder.Entity("BlazingPizza.PizzaTopping", (Action<EntityTypeBuilder>) (b =>
      {
        b.HasOne("BlazingPizza.Pizza", (string) null).WithMany("Toppings").HasForeignKey("PizzaId").OnDelete(DeleteBehavior.Cascade).IsRequired();
        b.HasOne("BlazingPizza.Topping", "Topping").WithMany().HasForeignKey("ToppingId").OnDelete(DeleteBehavior.Cascade).IsRequired();
      }));
      modelBuilder.Entity("BlazingPizza.SpecialEventCategory", (Action<EntityTypeBuilder>) (b => b.HasOne("BlazingPizza.PizzaSpecial", (string) null).WithMany("SpecialEvents").HasForeignKey("PizzaSpecialId")));
    }
  }
}
