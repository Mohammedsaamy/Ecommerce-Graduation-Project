namespace Group_4_Intake_44.Context
{
    public partial class gis44_SupplyChainContext : IdentityDbContext<ApplicationUser>
    {
        public gis44_SupplyChainContext()
        {
        }

        public gis44_SupplyChainContext(DbContextOptions<gis44_SupplyChainContext> options)
            : base(options)
        {
        }

        // Tabels Created In Database
        public virtual DbSet<Cart_Item> Cart_Items { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderHeader> OrderHeaders { get; set; }
        public virtual DbSet<Order_Item> Order_Items { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shopping_Cart> Shopping_Carts { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Store_Product> Store_Products { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Wishlist> WishLists { get; set; }
        public virtual  DbSet<WishlistItems> WishListItems { get; set; }


        // Make Relation Between Tabels (FK)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // Ensure Identity configurations are applied

            modelBuilder.Entity<Cart_Item>(entity =>
            {
                entity.HasOne(d => d.Product).WithMany(p => p.Cart_Items).HasConstraintName("FK_Cart Items_Product");

                entity.HasOne(d => d.ShoppingCart).WithMany(p => p.Cart_Items).HasConstraintName("FK_Cart Items_Shopping Cart");
            });

            modelBuilder.Entity<Order_Item>(entity =>
            {
                entity.HasOne(d => d.OrederHearder).WithMany(p => p.Order_Items).HasConstraintName("FK_Order Items_OrderHeader");

                entity.HasOne(d => d.Product).WithMany(p => p.Order_Items).HasConstraintName("FK_Order Items_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.Brand).WithMany(p => p.Products).HasConstraintName("FK_Product_Brand");
            });

            modelBuilder.Entity<Store_Product>(entity =>
            {
                entity.HasOne(d => d.Product).WithMany(p => p.Store_Products).HasConstraintName("FK_Store Product_Product");

                entity.HasOne(d => d.Store).WithMany(p => p.Store_Products).HasConstraintName("FK_Store Product_Stores");

                //entity.HasKey(sp => new { sp.StoreID, sp.ProductID });

                //entity.HasOne(sp => sp.Store).WithMany(s => s.Store_Products).HasForeignKey(sp => sp.StoreID);

                //entity.HasOne(sp => sp.Product).WithMany(p => p.Store_Products).HasForeignKey(sp => sp.ProductID);

            });

            OnModelCreatingPartial(modelBuilder);

            //Data In Category Table
            modelBuilder.Entity<Category>().HasData(new Category
            {
                ID = 1,
                Name = "Laptops"
            }, new Category
            {
                ID = 2,
                Name = "SmartPhone"
            }, new Category
            {
                ID = 3,
                Name = "SmartWatch"
            }, new Category
            {
                ID = 4,
                Name = "TVs"
            }, new Category
            {
                ID = 5,
                Name = "Wierless Headphone"
            });

            //Data In Brand Table
            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Brand_ID = 1,
                Name = "Apple"
            }, new Brand
            {
                Brand_ID = 2,
                Name = "ASUS"
            }, new Brand
            {
                Brand_ID = 3,
                Name = "HP"
            }, new Brand
            {
                Brand_ID = 4,
                Name = "Lenovo"
            }, new Brand
            {
                Brand_ID = 5,
                Name = "Dell"
            }, new Brand
            {
                Brand_ID = 6,
                Name = "Samsung"
            }, new Brand
            {
                Brand_ID = 7,
                Name = "Xiaomi"
            }, new Brand
            {
                Brand_ID = 8,
                Name = "Huawei"
            }, new Brand
            {
                Brand_ID = 9,
                Name = "LG"
            });

            //Data In Product Table
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = 1,
                Name = "Apple MacBook Air - M1 chip",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 47999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/a/za138.png",
                Description = "Apple MacBook Air - M1 chip with 8-core CPU and 7-core GPU - 8GB - 256GB - M1 chip -13 inch - MacOs - Space Grey",
                BrandID = 1,
                Quantity = 165
            }, new Product
            {
                ID = 2,
                Name = "Apple Macbook Air - M2 chip",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 65999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/a/za508.png",
                Description = "Apple Macbook Air M2 Laptop - M2 chip 8 Cores CPU With 8 Cores GPU - 8GB - 256 GB - 13 inch - Space Gray",
                BrandID = 1,
                Quantity = 163
            }, new Product
            {
                ID = 3,
                Name = "Apple Macbook Pro M3",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 107999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/a/za208.png",
                Description = "Apple Macbook Pro M3 - 8 Cores CPU With 10 Cores GPU - 8GB - 512GB SSD - 14 inch MacOs - Silver",
                BrandID = 1,
                Quantity = 164
            }, new Product
            {
                ID = 4,
                Name = "ASUS TUF Gaming F15",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 69999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/u/zu617-1.png",
                Description = "ASUS TUF Gaming F15 FA507VV4-LP105W Laptop - Intel® Core™ i9-13900H - 16GB - 512GB SSD - NVIDIA® GeForce® RTX™ 4060 8GB - 15.6'' FHD - Win11 - Gray",
                BrandID = 2,
                Quantity = 168
            }, new Product
            {
                ID = 5,
                Name = "ASUS Zenbook 14 OLED",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 77999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/u/zu462-1_1.png",
                Description = "ASUS Zenbook 14 OLED UX3405MA-PP381WS Laptop - Intel® Core™ Ultra 7-155H - 16GB - 1TB SSD - Intel® Arc™ Graphics - 14.0'' OLED - Win11 - Ponder Blue",
                BrandID = 2,
                Quantity = 169
            }, new Product
            {
                ID = 6,
                Name = "ASUS Zenbook 13 OLED",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 60599.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/u/zu465.png",
                Description = "ASUS Zenbook 13 OLED UX5304MA-NQ007WS Laptop - Intel® Ultra 7-155U - 16GB - 1TB SSD - Intel® Iris Xe Graphics - 13.3 FHD OLED - Win11 - Ponder Blude",
                BrandID = 2,
                Quantity = 167
            }, new Product
            {
                ID = 7,
                Name = "HP EliteBook 840 G8 Laptop",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 59999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/i/zi058-1-2b_2_1.jpg",
                Description = "HP EliteBook 840 G8 Laptop - Intel® Core™ i7-1165G7 - 8 GB - 512GB SSD - Intel® Iris® Xᵉ Graphics - 14” FHD - Windows 11 Pro - Silver",
                BrandID = 3,
                Quantity = 159
            }, new Product
            {
                ID = 8,
                Name = "HP ENVY x360 13-bf0001ne Laptop ",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 59799.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/h/zh392-1-2bjpg.jpg",
                Description = "HP ENVY x360 13-bf0001ne Laptop - Intel® Core™ i7-1250U - 16GB - 1TB SSD - Intel® Iris® Xᵉ Graphics - 13.3 WUXGA - Win11 - Natural Silver",
                BrandID = 3,
                Quantity = 162
            }, new Product
            {
                ID = 9,
                Name = "HP ProBook 450 G9 Laptop",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 45999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/h/zh897-1-2b_1.jpg",
                Description = "HP ProBook 450 G9 Laptop - Intel® Core™ i7-1255U - 8GB - 512GB SSD - NVIDIA® GeForce® MX570 - 15.6 HD - Silver Aluminum",
                BrandID = 3,
                Quantity = 154
            }, new Product
            {
                ID = 10,
                Name = "Lenovo Legion 7 Pro",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 165999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/l/zl880-new.png",
                Description = "Lenovo Legion 7 Pro 16IRX8H Laptop - Intel® Core™ i9-13900HX -32GB - 1TBSSD - NVIDIA® GeForce RTX™ 4090 16GB - 16 WQXGA - Win11 - Onyx Grey",
                BrandID = 4,
                Quantity = 156
            }, new Product
            {
                ID = 11,
                Name = "Lenovo Legion 5 16IRX9",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 89999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/l/zl420-new.png",
                Description = "Lenovo Legion 5 16IRX9 Laptop - Intel® Core™ i7-14650HX - 16GB - 1TB SSD - NVIDIA® GeForce RTX™ 4060 8GB - 16 WQXGA - Win11 - Luna Grey",
                BrandID = 4,
                Quantity = 156
            }, new Product
            {
                ID = 12,
                Name = "Lenovo ThinkPad-E14",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 58999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/l/zl415-1_1.png",
                Description = "Lenovo ThinkPad-E14 Laptop - Intel® Core™ i7-1355U - 8GB - 512GB SSD - NVIDIA® Geforce MX550 2GB - 14.0 FHD - Graphite Black",
                BrandID = 4,
                Quantity = 151
            }, new Product
            {
                ID = 13,
                Name = "Lenovo IdeaPad 5",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 31999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/d33f1c152d6eb7e8608a208d80f21a14/z/l/zl350-2b-1y.jpg",
                Description = "Lenovo IdeaPad 5 15ITL05 Laptop - Intel® Core™ i7-1165G7 - 8GB - 512 SSD - NVIDIA® GeForce MX450 2GB - 15.6 FHD - Grey",
                BrandID = 4,
                Quantity = 149
            }, new Product
            {
                ID = 14,
                Name = "Dell Latitude 5430 XCTO",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 639000.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/d/zd062-edited.jpg",
                Description = "Skip to the beginning of the images gallery Dell Latitude 5430 XCTO Laptop - Intel® Core™ i7-1265U vPro - 16 GB - 512 GB SSD - Intel Iris Xe Graphics -14” FHD - Silver",
                BrandID = 5,
                Quantity = 147
            }, new Product
            {
                ID = 15,
                Name = "Dell Gaming 5530 G15",
                CategoryID = 1,
                SpecialTag = " ",
                Price = 50999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/d/zd190.png",
                Description = "Dell Gaming 5530 G15 Laptop - Intel® Core™ i7-13650HX - 16GB - 512GB SSD - NVIDIA® GeForce RTX™ 3050 6GB - 15.6 FHD - Win 10 - Dark Shadow Grey",
                BrandID = 5,
                Quantity = 159
            }, new Product
            {
                ID = 16,
                Name = "Apple iPhone 15 Pro Max 256GB - Black",
                CategoryID = 2,
                SpecialTag = " ",
                Price = 66999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/m/a/ma645-1.jpg",
                Description = "The iPhone 15 Pro Max display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.69 inches diagonally",
                BrandID = 1,
                Quantity = 161
            }, new Product
            {
                ID = 17,
                Name = "Apple iPhone 15 Pro - 128GB - Black",
                CategoryID = 2,
                SpecialTag = " ",
                Price = 42999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/m/a/ma762-1_1.jpg",
                Description = "The iPhone 15 Pro display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.12 inches diagonally",
                BrandID = 1,
                Quantity = 151
            }, new Product
            {
                ID = 18,
                Name = "Apple iPhone 14 - 128GB - Blue",
                CategoryID = 2,
                SpecialTag = " ",
                Price = 35999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/i/p/iphone14-6.jpg",
                Description = "The iPhone 14 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle",
                BrandID = 1,
                Quantity = 159
            }, new Product
            {
                ID = 19,
                Name = "Apple Watch Ultra 49MM Titanium -",
                CategoryID = 3,
                SpecialTag = " ",
                Price = 44999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/w/t/wt705-1-min.jpg",
                Description = "",
                BrandID = 1,
                Quantity = 169
            }, new Product
            {
                ID = 20,
                Name = "Apple Watch Ultra 49MM Titanium Case Black Alpine Loop",
                CategoryID = 3,
                SpecialTag = " ",
                Price = 44999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/w/t/wt305-1.jpg",
                Description = "",
                BrandID = 1,
                Quantity = 187
            }, new Product
            {
                ID = 21,
                Name = "Samsung Galaxy A15",
                CategoryID = 2,
                SpecialTag = " ",
                Price = 8799.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/b/l/black-min_3.jpg",
                Description = "Samsung Galaxy A15 - 8GB RAM - 256GB - Blue Black",
                BrandID = 6,
                Quantity = 187
            }, new Product
            {
                ID = 22,
                Name = "Samsung Galaxy Tab A9",
                CategoryID = 2,
                SpecialTag = " ",
                Price = 7899.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/g/zg749-1.jpg",
                Description = "Samsung Galaxy Tab A9 - 4GB RAM - 64GB - Navy",
                BrandID = 6,
                Quantity = 187
            }, new Product
            {
                ID = 23,
                Name = "Samsung Galaxy A34",
                CategoryID = 2,
                SpecialTag = " ",
                Price = 14899.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/s/a/samsung_galaxy_a34-black_0003_layer_1_1.jpg",
                Description = "Samsung Galaxy A34 - 8GB RAM - 256GB - Black",
                BrandID = 6,
                Quantity = 187
            }, new Product
            {
                ID = 24,
                Name = "Samsung Galaxy A55 5G",
                CategoryID = 2,
                SpecialTag = " ",
                Price = 21999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/g/zg.png",
                Description = "Samsung Galaxy A55 5G - 8GB RAM - 128GB - Ice BLUE",
                BrandID = 6,
                Quantity = 187
            }, new Product
            {
                ID = 25,
                Name = "Xiaomi Redmi 10C",
                CategoryID = 2,
                SpecialTag = " ",
                Price = 8899.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/x/i/xiaomi-redmi-note-12-3_1.jpg",
                Description = "Xiaomi Redmi 10C - 4GB RAM - 64GB - Green",
                BrandID = 7,
                Quantity = 187
            }, new Product
            {
                ID = 26,
                Name = "Xiaomi Redmi Note 12",
                CategoryID = 2,
                SpecialTag = " ",
                Price = 7799.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/x/i/xiaomi-redmi-note--sunrise-gold-1_1.jpg",
                Description = "Xiaomi Redmi Note 12 - 6GB RAM - 128GB - Sunrise Gold",
                BrandID = 7,
                Quantity = 187
            }, new Product
            {
                ID = 27,
                Name = "Xiaomi Redmi Pad 6",
                CategoryID = 2,
                SpecialTag = " ",
                Price = 17999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/r/zr610-1.jpg",
                Description = "Xiaomi Redmi Pad 6 - 8GB RAM - 256GB - Grey",
                BrandID = 7,
                Quantity = 187
            }, new Product
            {
                ID = 28,
                Name = "Xiaomi Watch S1 - Black",
                CategoryID = 3,
                SpecialTag = " ",
                Price = 7499.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/w/t/wt206-10-min.jpg",
                Description = "Xiaomi Redmi Pad 6 - 8GB RAM - 256GB - Grey",
                BrandID = 7,
                Quantity = 187
            }, new Product
            {
                ID = 29,
                Name = "Huawei Band 7 - Black (PH Warranty)",
                CategoryID = 3,
                SpecialTag = " ",
                Price = 1999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/w/t/wt044-1-min_1.jpg",
                Description = "",
                BrandID = 8,
                Quantity = 187
            }, new Product
            {
                ID = 30,
                Name = "Huawei Nova 10 SE 8GB RAM - 256GB - Silver",
                CategoryID = 2,
                SpecialTag = " ",
                Price = 13999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/h/u/huawei-nova-10-se-silver-1.jpg",
                Description = "",
                BrandID = 8,
                Quantity = 187
            }, new Product
            {
                ID = 31,
                Name = "Huawei Watch GT 4 46 mm - Brown",
                CategoryID = 3,
                SpecialTag = " ",
                Price = 10499.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/g/t/gt4-min_2_1_1.jpg",
                Description = "",
                BrandID = 8,
                Quantity = 187
            }, new Product
            {
                ID = 32,
                Name = "Huawei nova Y91 - 8GB RAM - 256GB - Midnight Black",
                CategoryID = 2,
                SpecialTag = " ",
                Price = 13999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/m/i/mi702--66.jpg",
                Description = "",
                BrandID = 8,
                Quantity = 187
            }, new Product
            {
                ID = 33,
                Name = "Huawei nova Y61 - 4GB RAM - 64GB - Sapphire Blue",
                CategoryID = 2,
                SpecialTag = " ",
                Price = 6799.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/m/i/mi884-67.jpg",
                Description = "",
                BrandID = 8,
                Quantity = 187
            }, new Product
            {
                ID = 34,
                Name = "Samsung TV 65 LED UHD Smart Built In Receiver - CU8000",
                CategoryID = 4,
                SpecialTag = " ",
                Price = 27899.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/t/v/tv422-00-min.jpg",
                Description = "",
                BrandID = 6,
                Quantity = 187
            }, new Product
            {
                ID = 35,
                Name = "Samsung TV 43 Inch FHD LED Smart - Model",
                CategoryID = 4,
                SpecialTag = " ",
                Price = 14099.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/t/v/tv187-00-min.jpg",
                Description = "",
                BrandID = 6,
                Quantity = 187
            }, new Product
            {
                ID = 36,
                Name = "Samsung TV 65 Inch OLED 4K UHD Smart Built In Receiver",
                CategoryID = 4,
                SpecialTag = " ",
                Price = 84999.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/t/v/tv220-1-min.jpg",
                Description = "",
                BrandID = 6,
                Quantity = 187
            }, new Product
            {
                ID = 37,
                Name = "Samsung TV 55 LED UHD Smart Built In Receiver ",
                CategoryID = 4,
                SpecialTag = " ",
                Price = 23699.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/t/v/tv422-00-min_1.jpg",
                Description = "",
                BrandID = 6,
                Quantity = 187
            }, new Product
            {
                ID = 38,
                Name = "LG TV 43 LED UHD Smart Built In Receiver",
                CategoryID = 4,
                SpecialTag = " ",
                Price = 16499.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/t/v/tv770-00-min.jpg",
                Description = "",
                BrandID = 9,
                Quantity = 187
            }, new Product
            {
                ID = 39,
                Name = "LG 55 LED UHD Smart Built In Receiver with Magic Remote",
                CategoryID = 4,
                SpecialTag = " ",
                Price = 21699.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/t/v/tv775-1_1_1_1.jpg",
                Description = "",
                BrandID = 9,
                Quantity = 187
            }, new Product
            {
                ID = 40,
                Name = "Xiaomi Redmi Buds 3 Pro - Glacier Gray",
                CategoryID = 5,
                SpecialTag = " ",
                Price = 1100.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/h/p/hp291-1.jpg",
                Description = "",
                BrandID = 7,
                Quantity = 187
            }, new Product
            {
                ID = 41,
                Name = "Xiaomi Redmi Buds 3T Pro - Aurora Green",
                CategoryID = 5,
                SpecialTag = " ",
                Price = 4200.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/h/p/hp294-1-min.jpg",
                Description = "",
                BrandID = 7,
                Quantity = 182
            }, new Product
            {
                ID = 42,
                Name = "Xiaomi Buds 3 TWS Earphone - White",
                CategoryID = 5,
                SpecialTag = " ",
                Price = 2899.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/h/p/hp760-11-min_1.jpg",
                Description = "",
                BrandID = 7,
                Quantity = 174
            }, new Product
            {
                ID = 43,
                Name = "Apple AirPods 3rd Generation - White",
                CategoryID = 5,
                SpecialTag = " ",
                Price = 10899.00,
                Image = "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/h/p/hp252-12.jpg",
                Description = "",
                BrandID = 1,
                Quantity = 168
            });

            //Data In Store Table
            modelBuilder.Entity<Store>().HasData(new Store
            {
                ID = 1,
                Name = "bab elshaaria",
                Address = "علام حسين، النصر، باب الشعرية، محافظة القاهرة‬ 11311",
                Long = 30.0663938564418,
                Lat = 31.2646397978119,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 10
            }, new Store
            {
                ID = 2,
                Name = "Rod elfarag",
                Address = "طوسون،روضالفرج،محافظةالقاهرة‬ 11311",
                Long = 30.0842198767313,
                Lat = 31.2436971126076,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 15
            }, new Store
            {
                ID = 3,
                Name = "Nasr city",
                Address = "شارع مكرم عبيد، المنطقة السادسة، مدينة نصر، محافظة القاهرة‬ 4450345",
                Long = 30.0686854249143,
                Lat = 31.3436508275011,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 15
            }, new Store
            {
                ID = 4,
                Name = "new cairo",
                Address = "4J5H+M95، مدينتى، ثانى القاهرة الجديدة،، ثانى القاهرة الجديدة، محافظة القاهرة‬",
                Long = 30.0839302318766,
                Lat = 31.4531707860657,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 5
            }, new Store
            {
                ID = 5,
                Name = "el shrouq",
                Address = "1st settlement. Mustafa Kamel Axis close to English School Suiz Road، محافظة الق, محافظة القاهرة‬",
                Long = 30.1137260222809,
                Lat = 31.6274499989717,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 14
            }, new Store
            {
                ID = 6,
                Name = "Golf City mall obour",
                Address = "جولف سيتي مول, العبور، محافظة القليوبية 13612",
                Long = 30.1772603400985,
                Lat = 31.4757013397826,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 5
            }, new Store
            {
                ID = 7,
                Name = "Obour City",
                Address = "نادي العبور الرياضي, مدينة العبور، العبور، محافظة القاهرة‬ 11828",
                Long = 30.2383808709682,
                Lat = 31.4571619082192,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 5
            }, new Store
            {
                ID = 8,
                Name = "el salam",
                Address = "5C29+6W6، السلام الشرقية، قسم أول السلام، محافظة القاهرة‬ 4645101",
                Long = 30.1519554277053,
                Lat = 31.4193320370425,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 8
            }, new Store
            {
                ID = 9,
                Name = "el salam 2",
                Address = "بركة النصر، قسم أول السلام، محافظة القاهرة‬ 4642286",
                Long = 30.1451271831222,
                Lat = 31.3977027032954,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 10
            }, new Store
            {
                ID = 10,
                Name = "Badr bark",
                Address = "حديقة بدر، جسر السويس، الخصوص، قسم أول السلام، محافظة القاهرة‬ 11772",
                Long = 30.1369623574961,
                Lat = 31.3678336227699,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 12
            }, new Store
            {
                ID = 11,
                Name = "Gesr Elsuez",
                Address = "مصطفى حافظ،, جسر السويس، محافظة القاهرة‬ 11311",
                Long = 30.129242264751,
                Lat = 31.3510108065506,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 8
            }, new Store
            {
                ID = 12,
                Name = "Ein shams",
                Address = "العشرين، عين شمس الشرقية، عين شمس،، محافظة القاهرة‬",
                Long = 30.1385953764255,
                Lat = 31.3391661723281,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 10
            }, new Store
            {
                ID = 13,
                Name = "mataria",
                Address = "المطرية، العزب، قسم المطرية، محافظة القاهرة‬ 11753",
                Long = 30.1212246065414,
                Lat = 31.3031172855641,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 15
            }, new Store
            {
                ID = 14,
                Name = "Gesr Elsuez",
                Address = "جسر السويس، المطار، قسم عين شمس، محافظة القاهرة‬ 4542362",
                Long = 30.1212246064693,
                Lat = 31.3395094956183,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 10
            }, new Store
            {
                ID = 15,
                Name = "Heliopolis",
                Address = "204 El Nozha Street, Heliopolis, the first of the Hijaz Bridge MASR ELGEDIDA, محافظة القاهرة‬ 11757",
                Long = 30.1114243624012,
                Lat = 31.3450026593157,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 15
            }, new Store
            {
                ID = 16,
                Name = "Nozha",
                Address = "النزهة، قسم مصر الجديدة، محافظة القاهرة‬ 11311",
                Long = 30.1022171868583,
                Lat = 31.3417410933704,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 5
            }, new Store
            {
                ID = 17,
                Name = "qesm masr elgedida",
                Address = "1 شارع عمر إبن الخطاب - بجوار مدرسه نوتردام - من ميدان الإسماعيلية، قسم مصر الجديدة، محافظة القاهرة‬ 11511",
                Long = 30.1019201669127,
                Lat = 31.3335013478243,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 10
            }, new Store
            {
                ID = 18,
                Name = "qesm masr elgedida2",
                Address = "آخر سور مستشفى العاصمه، 2 شارع شبين، صلاح الدين، قسم مصر الجديدة، محافظة القاهرة‬ 11511",
                Long = 30.0965736552556,
                Lat = 31.3298964591479,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 10
            }, new Store
            {
                ID = 19,
                Name = "elcorba",
                Address = "ميدان الكوربة شارع الاهرام MASR ELGEDIDA, محافظة القاهرة‬ 11757",
                Long = 30.0958310609682,
                Lat = 31.3223433589727,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 12
            }, new Store
            {
                ID = 20,
                Name = "elgiza ",
                Address = "شارع الملك فيصل، عطاطي، الهرم، محافظة الجيزة 3553021",
                Long = 29.9986517202504,
                Lat = 31.1529135789958,
                MobileNumber = "+201157760283",
                whatsappNumber = "+201019879660",
                FacebookLink = "//ourStore.com",
                CarNumbers = 18
            });

            //Data In Store Product Table
            modelBuilder.Entity<Store_Product>().HasData(new Store_Product
            {
                ID = 1,
                StoreID = 1,
                ProductID = 1,
                Quantity = 5
            }, new Store_Product
            {
                ID = 2,
                StoreID = 1,
                ProductID = 2,
                Quantity = 5
            }, new Store_Product
            {
                ID = 3,
                StoreID = 1,
                ProductID = 3,
                Quantity = 5
            }, new Store_Product
            {
                ID = 4,
                StoreID = 1,
                ProductID = 4,
                Quantity = 5
            }, new Store_Product
            {
                ID = 5,
                StoreID = 1,
                ProductID = 5,
                Quantity = 5
            }, new Store_Product
            {
                ID = 6,
                StoreID = 1,
                ProductID = 6,
                Quantity = 5
            }, new Store_Product
            {
                ID = 7,
                StoreID = 1,
                ProductID = 7,
                Quantity = 5
            }, new Store_Product
            {
                ID = 8,
                StoreID = 1,
                ProductID = 8,
                Quantity = 5
            }, new Store_Product
            {
                ID = 9,
                StoreID = 1,
                ProductID = 9,
                Quantity = 5
            }, new Store_Product
            {
                ID = 10,
                StoreID = 1,
                ProductID = 10,
                Quantity = 5
            }, new Store_Product
            {
                ID = 11,
                StoreID = 1,
                ProductID = 11,
                Quantity = 5
            }, new Store_Product
            {
                ID = 12,
                StoreID = 1,
                ProductID = 12,
                Quantity = 5
            }, new Store_Product
            {
                ID = 13,
                StoreID = 1,
                ProductID = 13,
                Quantity = 5
            }, new Store_Product
            {
                ID = 14,
                StoreID = 1,
                ProductID = 14,
                Quantity = 5
            }, new Store_Product
            {
                ID = 15,
                StoreID = 1,
                ProductID = 15,
                Quantity = 5
            }, new Store_Product
            {
                ID = 16,
                StoreID = 1,
                ProductID = 16,
                Quantity = 5
            }, new Store_Product
            {
                ID = 17,
                StoreID = 1,
                ProductID = 17,
                Quantity = 5
            }, new Store_Product
            {
                ID = 18,
                StoreID = 1,
                ProductID = 18,
                Quantity = 5
            }, new Store_Product
            {
                ID = 19,
                StoreID = 1,
                ProductID = 19,
                Quantity = 5
            }, new Store_Product
            {
                ID = 20,
                StoreID = 1,
                ProductID = 20,
                Quantity = 5
            }, new Store_Product
            {
                ID = 21,
                StoreID = 1,
                ProductID = 21,
                Quantity = 5
            }, new Store_Product
            {
                ID = 22,
                StoreID = 1,
                ProductID = 22,
                Quantity = 5
            }, new Store_Product
            {
                ID = 23,
                StoreID = 1,
                ProductID = 23,
                Quantity = 5
            }, new Store_Product
            {
                ID = 24,
                StoreID = 1,
                ProductID = 24,
                Quantity = 5
            }, new Store_Product
            {
                ID = 25,
                StoreID = 1,
                ProductID = 25,
                Quantity = 5
            }, new Store_Product
            {
                ID = 26,
                StoreID = 1,
                ProductID = 26,
                Quantity = 5
            }, new Store_Product
            {
                ID = 27,
                StoreID = 1,
                ProductID = 27,
                Quantity = 5
            }, new Store_Product
            {
                ID = 28,
                StoreID = 1,
                ProductID = 28,
                Quantity = 5
            }, new Store_Product
            {
                ID = 29,
                StoreID = 1,
                ProductID = 29,
                Quantity = 5
            }, new Store_Product
            {
                ID = 30,
                StoreID = 1,
                ProductID = 30,
                Quantity = 5
            }, new Store_Product
            {
                ID = 31,
                StoreID = 1,
                ProductID = 31,
                Quantity = 5
            }, new Store_Product
            {
                ID = 32,
                StoreID = 1,
                ProductID = 32,
                Quantity = 5
            }, new Store_Product
            {
                ID = 33,
                StoreID = 1,
                ProductID = 33,
                Quantity = 5
            }, new Store_Product
            {
                ID = 34,
                StoreID = 1,
                ProductID = 34,
                Quantity = 5
            }, new Store_Product
            {
                ID = 35,
                StoreID = 1,
                ProductID = 35,
                Quantity = 5
            }, new Store_Product
            {
                ID = 36,
                StoreID = 1,
                ProductID = 36,
                Quantity = 5
            }, new Store_Product
            {
                ID = 37,
                StoreID = 1,
                ProductID = 37,
                Quantity = 5
            }, new Store_Product
            {
                ID = 38,
                StoreID = 1,
                ProductID = 38,
                Quantity = 5
            }, new Store_Product
            {
                ID = 39,
                StoreID = 1,
                ProductID = 39,
                Quantity = 5
            }, new Store_Product
            {
                ID = 40,
                StoreID = 1,
                ProductID = 40,
                Quantity = 5
            }, new Store_Product
            {
                ID = 41,
                StoreID = 2,
                ProductID = 2,
                Quantity = 8
            }, new Store_Product
            {
                ID = 42,
                StoreID = 2,
                ProductID = 3,
                Quantity = 8
            }, new Store_Product
            {
                ID = 43,
                StoreID = 2,
                ProductID = 4,
                Quantity = 8
            }, new Store_Product
            {
                ID = 44,
                StoreID = 2,
                ProductID = 5,
                Quantity = 8
            }, new Store_Product
            {
                ID = 45,
                StoreID = 2,
                ProductID = 6,
                Quantity = 8
            }, new Store_Product
            {
                ID = 46,
                StoreID = 2,
                ProductID = 7,
                Quantity = 8
            }, new Store_Product
            {
                ID = 47,
                StoreID = 2,
                ProductID = 8,
                Quantity = 8
            }, new Store_Product
            {
                ID = 48,
                StoreID = 2,
                ProductID = 9,
                Quantity = 8
            }, new Store_Product
            {
                ID = 49,
                StoreID = 2,
                ProductID = 10,
                Quantity = 8
            }, new Store_Product
            {
                ID = 50,
                StoreID = 2,
                ProductID = 11,
                Quantity = 8
            }, new Store_Product
            {
                ID = 51,
                StoreID = 2,
                ProductID = 12,
                Quantity = 8
            }, new Store_Product
            {
                ID = 52,
                StoreID = 2,
                ProductID = 13,
                Quantity = 8
            }, new Store_Product
            {
                ID = 53,
                StoreID = 2,
                ProductID = 14,
                Quantity = 8
            }, new Store_Product
            {
                ID = 54,
                StoreID = 2,
                ProductID = 15,
                Quantity = 8
            }, new Store_Product
            {
                ID = 55,
                StoreID = 2,
                ProductID = 16,
                Quantity = 8
            }, new Store_Product
            {
                ID = 56,
                StoreID = 2,
                ProductID = 17,
                Quantity = 8
            }, new Store_Product
            {
                ID = 57,
                StoreID = 2,
                ProductID = 18,
                Quantity = 8
            }, new Store_Product
            {
                ID = 58,
                StoreID = 2,
                ProductID = 19,
                Quantity = 8
            }, new Store_Product
            {
                ID = 59,
                StoreID = 2,
                ProductID = 20,
                Quantity = 8
            }, new Store_Product
            {
                ID = 60,
                StoreID = 2,
                ProductID = 21,
                Quantity = 8
            }, new Store_Product
            {
                ID = 61,
                StoreID = 2,
                ProductID = 22,
                Quantity = 8
            }, new Store_Product
            {
                ID = 62,
                StoreID = 2,
                ProductID = 23,
                Quantity = 8
            }, new Store_Product
            {
                ID = 63,
                StoreID = 2,
                ProductID = 24,
                Quantity = 8
            }, new Store_Product
            {
                ID = 64,
                StoreID = 2,
                ProductID = 25,
                Quantity = 8
            }, new Store_Product
            {
                ID = 65,
                StoreID = 2,
                ProductID = 26,
                Quantity = 8
            }, new Store_Product
            {
                ID = 66,
                StoreID = 2,
                ProductID = 27,
                Quantity = 8
            }, new Store_Product
            {
                ID = 67,
                StoreID = 2,
                ProductID = 28,
                Quantity = 8
            }, new Store_Product
            {
                ID = 68,
                StoreID = 2,
                ProductID = 29,
                Quantity = 8
            }, new Store_Product
            {
                ID = 69,
                StoreID = 2,
                ProductID = 30,
                Quantity = 8
            }, new Store_Product
            {
                ID = 70,
                StoreID = 2,
                ProductID = 31,
                Quantity = 8
            }, new Store_Product
            {
                ID = 71,
                StoreID = 2,
                ProductID = 32,
                Quantity = 8
            }, new Store_Product
            {
                ID = 72,
                StoreID = 2,
                ProductID = 33,
                Quantity = 8
            }, new Store_Product
            {
                ID = 73,
                StoreID = 2,
                ProductID = 34,
                Quantity = 8
            }, new Store_Product
            {
                ID = 74,
                StoreID = 2,
                ProductID = 35,
                Quantity = 8
            }, new Store_Product
            {
                ID = 75,
                StoreID = 2,
                ProductID = 36,
                Quantity = 8
            }, new Store_Product
            {
                ID = 76,
                StoreID = 2,
                ProductID = 37,
                Quantity = 8
            }, new Store_Product
            {
                ID = 77,
                StoreID = 2,
                ProductID = 38,
                Quantity = 8
            }, new Store_Product
            {
                ID = 78,
                StoreID = 2,
                ProductID = 39,
                Quantity = 8
            }, new Store_Product
            {
                ID = 79,
                StoreID = 2,
                ProductID = 40,
                Quantity = 8
            }, new Store_Product
            {
                ID = 80,
                StoreID = 2,
                ProductID = 41,
                Quantity = 8
            }, new Store_Product
            {
                ID = 81,
                StoreID = 3,
                ProductID = 3,
                Quantity = 6
            }, new Store_Product
            {
                ID = 82,
                StoreID = 3,
                ProductID = 4,
                Quantity = 6
            }, new Store_Product
            {
                ID = 83,
                StoreID = 3,
                ProductID = 5,
                Quantity = 6
            }, new Store_Product
            {
                ID = 84,
                StoreID = 3,
                ProductID = 6,
                Quantity = 6
            }, new Store_Product
            {
                ID = 85,
                StoreID = 3,
                ProductID = 7,
                Quantity = 6
            }, new Store_Product
            {
                ID = 86,
                StoreID = 3,
                ProductID = 8,
                Quantity = 6
            }, new Store_Product
            {
                ID = 87,
                StoreID = 3,
                ProductID = 9,
                Quantity = 6
            }, new Store_Product
            {
                ID = 88,
                StoreID = 3,
                ProductID = 10,
                Quantity = 6
            }, new Store_Product
            {
                ID = 89,
                StoreID = 3,
                ProductID = 11,
                Quantity = 6
            }, new Store_Product
            {
                ID = 90,
                StoreID = 3,
                ProductID = 12,
                Quantity = 6
            }, new Store_Product
            {
                ID = 91,
                StoreID = 3,
                ProductID = 13,
                Quantity = 6
            }, new Store_Product
            {
                ID = 92,
                StoreID = 3,
                ProductID = 14,
                Quantity = 6
            }, new Store_Product
            {
                ID = 93,
                StoreID = 3,
                ProductID = 15,
                Quantity = 6
            }, new Store_Product
            {
                ID = 94,
                StoreID = 3,
                ProductID = 16,
                Quantity = 6
            }, new Store_Product
            {
                ID = 95,
                StoreID = 3,
                ProductID = 17,
                Quantity = 6
            }, new Store_Product
            {
                ID = 96,
                StoreID = 3,
                ProductID = 18,
                Quantity = 6
            }, new Store_Product
            {
                ID = 97,
                StoreID = 3,
                ProductID = 19,
                Quantity = 6
            }, new Store_Product
            {
                ID = 98,
                StoreID = 3,
                ProductID = 20,
                Quantity = 6
            }, new Store_Product
            {
                ID = 99,
                StoreID = 3,
                ProductID = 21,
                Quantity = 6
            }, new Store_Product
            {
                ID = 100,
                StoreID = 3,
                ProductID = 22,
                Quantity = 6
            }, new Store_Product
            {
                ID = 101,
                StoreID = 3,
                ProductID = 23,
                Quantity = 6
            }, new Store_Product
            {
                ID = 102,
                StoreID = 3,
                ProductID = 24,
                Quantity = 6
            }, new Store_Product
            {
                ID = 103,
                StoreID = 3,
                ProductID = 25,
                Quantity = 6
            }, new Store_Product
            {
                ID = 104,
                StoreID = 3,
                ProductID = 26,
                Quantity = 6
            }, new Store_Product
            {
                ID = 105,
                StoreID = 3,
                ProductID = 27,
                Quantity = 6
            }, new Store_Product
            {
                ID = 106,
                StoreID = 3,
                ProductID = 28,
                Quantity = 6
            }, new Store_Product
            {
                ID = 107,
                StoreID = 3,
                ProductID = 29,
                Quantity = 6
            }, new Store_Product
            {
                ID = 108,
                StoreID = 3,
                ProductID = 30,
                Quantity = 6
            }, new Store_Product
            {
                ID = 109,
                StoreID = 3,
                ProductID = 31,
                Quantity = 6
            }, new Store_Product
            {
                ID = 110,
                StoreID = 3,
                ProductID = 32,
                Quantity = 6
            }, new Store_Product
            {
                ID = 111,
                StoreID = 3,
                ProductID = 33,
                Quantity = 6
            }, new Store_Product
            {
                ID = 112,
                StoreID = 3,
                ProductID = 34,
                Quantity = 6
            }, new Store_Product
            {
                ID = 113,
                StoreID = 3,
                ProductID = 35,
                Quantity = 6
            }, new Store_Product
            {
                ID = 114,
                StoreID = 3,
                ProductID = 36,
                Quantity = 6
            }, new Store_Product
            {
                ID = 115,
                StoreID = 3,
                ProductID = 37,
                Quantity = 6
            }, new Store_Product
            {
                ID = 116,
                StoreID = 3,
                ProductID = 38,
                Quantity = 6
            }, new Store_Product
            {
                ID = 117,
                StoreID = 3,
                ProductID = 39,
                Quantity = 6
            }, new Store_Product
            {
                ID = 118,
                StoreID = 3,
                ProductID = 40,
                Quantity = 6
            }, new Store_Product
            {
                ID = 119,
                StoreID = 3,
                ProductID = 41,
                Quantity = 6
            }, new Store_Product
            {
                ID = 120,
                StoreID = 3,
                ProductID = 42,
                Quantity = 6
            }, new Store_Product
            {
                ID = 121,
                StoreID = 4,
                ProductID = 4,
                Quantity = 8
            }, new Store_Product
            {
                ID = 122,
                StoreID = 4,
                ProductID = 5,
                Quantity = 8
            }, new Store_Product
            {
                ID = 123,
                StoreID = 4,
                ProductID = 6,
                Quantity = 8
            }, new Store_Product
            {
                ID = 124,
                StoreID = 4,
                ProductID = 7,
                Quantity = 8
            }, new Store_Product
            {
                ID = 125,
                StoreID = 4,
                ProductID = 8,
                Quantity = 8
            }, new Store_Product
            {
                ID = 126,
                StoreID = 4,
                ProductID = 9,
                Quantity = 8
            }, new Store_Product
            {
                ID = 127,
                StoreID = 4,
                ProductID = 10,
                Quantity = 8
            }, new Store_Product
            {
                ID = 128,
                StoreID = 4,
                ProductID = 11,
                Quantity = 8
            }, new Store_Product
            {
                ID = 129,
                StoreID = 4,
                ProductID = 12,
                Quantity = 8
            }, new Store_Product
            {
                ID = 130,
                StoreID = 4,
                ProductID = 13,
                Quantity = 8
            }, new Store_Product
            {
                ID = 131,
                StoreID = 4,
                ProductID = 14,
                Quantity = 8
            }, new Store_Product
            {
                ID = 132,
                StoreID = 4,
                ProductID = 15,
                Quantity = 8
            }, new Store_Product
            {
                ID = 133,
                StoreID = 4,
                ProductID = 16,
                Quantity = 8
            }, new Store_Product
            {
                ID = 134,
                StoreID = 4,
                ProductID = 17,
                Quantity = 8
            }, new Store_Product
            {
                ID = 135,
                StoreID = 4,
                ProductID = 18,
                Quantity = 8
            }, new Store_Product
            {
                ID = 136,
                StoreID = 4,
                ProductID = 19,
                Quantity = 8
            }, new Store_Product
            {
                ID = 137,
                StoreID = 4,
                ProductID = 20,
                Quantity = 8
            }, new Store_Product
            {
                ID = 138,
                StoreID = 4,
                ProductID = 21,
                Quantity = 8
            }, new Store_Product
            {
                ID = 139,
                StoreID = 4,
                ProductID = 22,
                Quantity = 8
            }, new Store_Product
            {
                ID = 140,
                StoreID = 4,
                ProductID = 23,
                Quantity = 8
            }, new Store_Product
            {
                ID = 141,
                StoreID = 4,
                ProductID = 24,
                Quantity = 8
            }, new Store_Product
            {
                ID = 142,
                StoreID = 4,
                ProductID = 25,
                Quantity = 8
            }, new Store_Product
            {
                ID = 143,
                StoreID = 4,
                ProductID = 26,
                Quantity = 8
            }, new Store_Product
            {
                ID = 144,
                StoreID = 4,
                ProductID = 27,
                Quantity = 8
            }, new Store_Product
            {
                ID = 145,
                StoreID = 4,
                ProductID = 28,
                Quantity = 8
            }, new Store_Product
            {
                ID = 146,
                StoreID = 4,
                ProductID = 29,
                Quantity = 8
            }, new Store_Product
            {
                ID = 147,
                StoreID = 4,
                ProductID = 30,
                Quantity = 8
            }, new Store_Product
            {
                ID = 148,
                StoreID = 4,
                ProductID = 31,
                Quantity = 8
            }, new Store_Product
            {
                ID = 149,
                StoreID = 4,
                ProductID = 32,
                Quantity = 8
            }, new Store_Product
            {
                ID = 150,
                StoreID = 4,
                ProductID = 33,
                Quantity = 8
            }, new Store_Product
            {
                ID = 151,
                StoreID = 4,
                ProductID = 34,
                Quantity = 8
            }, new Store_Product
            {
                ID = 152,
                StoreID = 4,
                ProductID = 35,
                Quantity = 8
            }, new Store_Product
            {
                ID = 153,
                StoreID = 4,
                ProductID = 36,
                Quantity = 8
            }, new Store_Product
            {
                ID = 154,
                StoreID = 4,
                ProductID = 37,
                Quantity = 8
            }, new Store_Product
            {
                ID = 155,
                StoreID = 4,
                ProductID = 38,
                Quantity = 8
            }, new Store_Product
            {
                ID = 156,
                StoreID = 4,
                ProductID = 39,
                Quantity = 8
            }, new Store_Product
            {
                ID = 157,
                StoreID = 4,
                ProductID = 40,
                Quantity = 8
            }, new Store_Product
            {
                ID = 158,
                StoreID = 4,
                ProductID = 41,
                Quantity = 8
            }, new Store_Product
            {
                ID = 159,
                StoreID = 4,
                ProductID = 42,
                Quantity = 8
            }, new Store_Product
            {
                ID = 160,
                StoreID = 4,
                ProductID = 43,
                Quantity = 8
            }, new Store_Product
            {
                ID = 161,
                StoreID = 5,
                ProductID = 1,
                Quantity = 10
            }, new Store_Product
            {
                ID = 162,
                StoreID = 5,
                ProductID = 5,
                Quantity = 10
            }, new Store_Product
            {
                ID = 163,
                StoreID = 5,
                ProductID = 6,
                Quantity = 10
            }, new Store_Product
            {
                ID = 164,
                StoreID = 5,
                ProductID = 7,
                Quantity = 10
            }, new Store_Product
            {
                ID = 165,
                StoreID = 5,
                ProductID = 8,
                Quantity = 10
            }, new Store_Product
            {
                ID = 166,
                StoreID = 5,
                ProductID = 9,
                Quantity = 10
            }, new Store_Product
            {
                ID = 167,
                StoreID = 5,
                ProductID = 10,
                Quantity = 10
            }, new Store_Product
            {
                ID = 168,
                StoreID = 5,
                ProductID = 11,
                Quantity = 10
            }, new Store_Product
            {
                ID = 169,
                StoreID = 5,
                ProductID = 12,
                Quantity = 10
            }, new Store_Product
            {
                ID = 170,
                StoreID = 5,
                ProductID = 13,
                Quantity = 10
            }, new Store_Product
            {
                ID = 171,
                StoreID = 5,
                ProductID = 14,
                Quantity = 10
            }, new Store_Product
            {
                ID = 172,
                StoreID = 5,
                ProductID = 15,
                Quantity = 10
            }, new Store_Product
            {
                ID = 173,
                StoreID = 5,
                ProductID = 16,
                Quantity = 10
            }, new Store_Product
            {
                ID = 174,
                StoreID = 5,
                ProductID = 17,
                Quantity = 10
            }, new Store_Product
            {
                ID = 175,
                StoreID = 5,
                ProductID = 18,
                Quantity = 10
            }, new Store_Product
            {
                ID = 176,
                StoreID = 5,
                ProductID = 19,
                Quantity = 10
            }, new Store_Product
            {
                ID = 177,
                StoreID = 5,
                ProductID = 20,
                Quantity = 10
            }, new Store_Product
            {
                ID = 178,
                StoreID = 5,
                ProductID = 21,
                Quantity = 10
            }, new Store_Product
            {
                ID = 179,
                StoreID = 5,
                ProductID = 22,
                Quantity = 10
            }, new Store_Product
            {
                ID = 180,
                StoreID = 5,
                ProductID = 23,
                Quantity = 10
            }, new Store_Product
            {
                ID = 181,
                StoreID = 5,
                ProductID = 24,
                Quantity = 10
            }, new Store_Product
            {
                ID = 182,
                StoreID = 5,
                ProductID = 25,
                Quantity = 10
            }, new Store_Product
            {
                ID = 183,
                StoreID = 5,
                ProductID = 26,
                Quantity = 10
            }, new Store_Product
            {
                ID = 184,
                StoreID = 5,
                ProductID = 27,
                Quantity = 10
            }, new Store_Product
            {
                ID = 185,
                StoreID = 5,
                ProductID = 28,
                Quantity = 10
            }, new Store_Product
            {
                ID = 186,
                StoreID = 5,
                ProductID = 29,
                Quantity = 10
            }, new Store_Product
            {
                ID = 187,
                StoreID = 5,
                ProductID = 30,
                Quantity = 10
            }, new Store_Product
            {
                ID = 188,
                StoreID = 5,
                ProductID = 31,
                Quantity = 10
            }, new Store_Product
            {
                ID = 189,
                StoreID = 5,
                ProductID = 32,
                Quantity = 10
            }, new Store_Product
            {
                ID = 190,
                StoreID = 5,
                ProductID = 33,
                Quantity = 10
            }, new Store_Product
            {
                ID = 191,
                StoreID = 5,
                ProductID = 34,
                Quantity = 10
            }, new Store_Product
            {
                ID = 192,
                StoreID = 5,
                ProductID = 35,
                Quantity = 10
            }, new Store_Product
            {
                ID = 193,
                StoreID = 5,
                ProductID = 36,
                Quantity = 10
            }, new Store_Product
            {
                ID = 194,
                StoreID = 5,
                ProductID = 37,
                Quantity = 10
            }, new Store_Product
            {
                ID = 195,
                StoreID = 5,
                ProductID = 38,
                Quantity = 10
            }, new Store_Product
            {
                ID = 196,
                StoreID = 5,
                ProductID = 39,
                Quantity = 10
            }, new Store_Product
            {
                ID = 197,
                StoreID = 5,
                ProductID = 40,
                Quantity = 10
            }, new Store_Product
            {
                ID = 198,
                StoreID = 5,
                ProductID = 41,
                Quantity = 10
            }, new Store_Product
            {
                ID = 199,
                StoreID = 5,
                ProductID = 42,
                Quantity = 10
            }, new Store_Product
            {
                ID = 200,
                StoreID = 5,
                ProductID = 43,
                Quantity = 10
            }, new Store_Product
            {
                ID = 201,
                StoreID = 6,
                ProductID = 1,
                Quantity = 5
            }, new Store_Product
            {
                ID = 202,
                StoreID = 6,
                ProductID = 2,
                Quantity = 5
            }, new Store_Product
            {
                ID = 203,
                StoreID = 6,
                ProductID = 6,
                Quantity = 5
            }, new Store_Product
            {
                ID = 204,
                StoreID = 6,
                ProductID = 7,
                Quantity = 5
            }, new Store_Product
            {
                ID = 205,
                StoreID = 6,
                ProductID = 8,
                Quantity = 5
            }, new Store_Product
            {
                ID = 206,
                StoreID = 6,
                ProductID = 9,
                Quantity = 5
            }, new Store_Product
            {
                ID = 207,
                StoreID = 6,
                ProductID = 10,
                Quantity = 5
            }, new Store_Product
            {
                ID = 208,
                StoreID = 6,
                ProductID = 11,
                Quantity = 5
            }, new Store_Product
            {
                ID = 209,
                StoreID = 6,
                ProductID = 12,
                Quantity = 5
            }, new Store_Product
            {
                ID = 210,
                StoreID = 6,
                ProductID = 13,
                Quantity = 5
            }, new Store_Product
            {
                ID = 211,
                StoreID = 6,
                ProductID = 14,
                Quantity = 5
            }, new Store_Product
            {
                ID = 212,
                StoreID = 6,
                ProductID = 15,
                Quantity = 5
            }, new Store_Product
            {
                ID = 213,
                StoreID = 6,
                ProductID = 16,
                Quantity = 5
            }, new Store_Product
            {
                ID = 214,
                StoreID = 6,
                ProductID = 17,
                Quantity = 5
            }, new Store_Product
            {
                ID = 215,
                StoreID = 6,
                ProductID = 18,
                Quantity = 5
            }, new Store_Product
            {
                ID = 216,
                StoreID = 6,
                ProductID = 19,
                Quantity = 5
            }, new Store_Product
            {
                ID = 217,
                StoreID = 6,
                ProductID = 20,
                Quantity = 5
            }, new Store_Product
            {
                ID = 218,
                StoreID = 6,
                ProductID = 21,
                Quantity = 5
            }, new Store_Product
            {
                ID = 219,
                StoreID = 6,
                ProductID = 22,
                Quantity = 5
            }, new Store_Product
            {
                ID = 220,
                StoreID = 6,
                ProductID = 23,
                Quantity = 5
            }, new Store_Product
            {
                ID = 221,
                StoreID = 6,
                ProductID = 24,
                Quantity = 5
            }, new Store_Product
            {
                ID = 222,
                StoreID = 6,
                ProductID = 25,
                Quantity = 5
            }, new Store_Product
            {
                ID = 223,
                StoreID = 6,
                ProductID = 26,
                Quantity = 5
            }, new Store_Product
            {
                ID = 224,
                StoreID = 6,
                ProductID = 27,
                Quantity = 5
            }, new Store_Product
            {
                ID = 225,
                StoreID = 6,
                ProductID = 28,
                Quantity = 5
            }, new Store_Product
            {
                ID = 226,
                StoreID = 6,
                ProductID = 29,
                Quantity = 5
            }, new Store_Product
            {
                ID = 227,
                StoreID = 6,
                ProductID = 30,
                Quantity = 5
            }, new Store_Product
            {
                ID = 228,
                StoreID = 6,
                ProductID = 31,
                Quantity = 5
            }, new Store_Product
            {
                ID = 229,
                StoreID = 6,
                ProductID = 32,
                Quantity = 5
            }, new Store_Product
            {
                ID = 230,
                StoreID = 6,
                ProductID = 33,
                Quantity = 5
            }, new Store_Product
            {
                ID = 231,
                StoreID = 6,
                ProductID = 34,
                Quantity = 5
            }, new Store_Product
            {
                ID = 232,
                StoreID = 6,
                ProductID = 35,
                Quantity = 5
            }, new Store_Product
            {
                ID = 233,
                StoreID = 6,
                ProductID = 36,
                Quantity = 5
            }, new Store_Product
            {
                ID = 234,
                StoreID = 6,
                ProductID = 37,
                Quantity = 5
            }, new Store_Product
            {
                ID = 235,
                StoreID = 6,
                ProductID = 38,
                Quantity = 5
            }, new Store_Product
            {
                ID = 236,
                StoreID = 6,
                ProductID = 39,
                Quantity = 5
            }, new Store_Product
            {
                ID = 237,
                StoreID = 6,
                ProductID = 40,
                Quantity = 5
            }, new Store_Product
            {
                ID = 238,
                StoreID = 6,
                ProductID = 41,
                Quantity = 5
            }, new Store_Product
            {
                ID = 239,
                StoreID = 6,
                ProductID = 42,
                Quantity = 5
            }, new Store_Product
            {
                ID = 240,
                StoreID = 6,
                ProductID = 43,
                Quantity = 5
            }, new Store_Product
            {
                ID = 241,
                StoreID = 7,
                ProductID = 1,
                Quantity = 4
            }, new Store_Product
            {
                ID = 242,
                StoreID = 7,
                ProductID = 2,
                Quantity = 4
            }, new Store_Product
            {
                ID = 243,
                StoreID = 7,
                ProductID = 3,
                Quantity = 4
            }, new Store_Product
            {
                ID = 244,
                StoreID = 7,
                ProductID = 7,
                Quantity = 4
            }, new Store_Product
            {
                ID = 245,
                StoreID = 7,
                ProductID = 8,
                Quantity = 4
            }, new Store_Product
            {
                ID = 246,
                StoreID = 7,
                ProductID = 9,
                Quantity = 4
            }, new Store_Product
            {
                ID = 247,
                StoreID = 7,
                ProductID = 10,
                Quantity = 4
            }, new Store_Product
            {
                ID = 248,
                StoreID = 7,
                ProductID = 11,
                Quantity = 4
            }, new Store_Product
            {
                ID = 249,
                StoreID = 7,
                ProductID = 12,
                Quantity = 4
            }, new Store_Product
            {
                ID = 250,
                StoreID = 7,
                ProductID = 13,
                Quantity = 4
            }, new Store_Product
            {
                ID = 251,
                StoreID = 7,
                ProductID = 14,
                Quantity = 4
            }, new Store_Product
            {
                ID = 252,
                StoreID = 7,
                ProductID = 15,
                Quantity = 4
            }, new Store_Product
            {
                ID = 253,
                StoreID = 7,
                ProductID = 16,
                Quantity = 4
            }, new Store_Product
            {
                ID = 254,
                StoreID = 7,
                ProductID = 17,
                Quantity = 4
            }, new Store_Product
            {
                ID = 255,
                StoreID = 7,
                ProductID = 18,
                Quantity = 4
            }, new Store_Product
            {
                ID = 256,
                StoreID = 7,
                ProductID = 19,
                Quantity = 4
            }, new Store_Product
            {
                ID = 257,
                StoreID = 7,
                ProductID = 20,
                Quantity = 4
            }, new Store_Product
            {
                ID = 258,
                StoreID = 7,
                ProductID = 21,
                Quantity = 4
            }, new Store_Product
            {
                ID = 259,
                StoreID = 7,
                ProductID = 22,
                Quantity = 4
            }, new Store_Product
            {
                ID = 260,
                StoreID = 7,
                ProductID = 23,
                Quantity = 4
            }, new Store_Product
            {
                ID = 261,
                StoreID = 7,
                ProductID = 24,
                Quantity = 4
            }, new Store_Product
            {
                ID = 262,
                StoreID = 7,
                ProductID = 25,
                Quantity = 4
            }, new Store_Product
            {
                ID = 263,
                StoreID = 7,
                ProductID = 26,
                Quantity = 4
            }, new Store_Product
            {
                ID = 264,
                StoreID = 7,
                ProductID = 27,
                Quantity = 4
            }, new Store_Product
            {
                ID = 265,
                StoreID = 7,
                ProductID = 28,
                Quantity = 4
            }, new Store_Product
            {
                ID = 266,
                StoreID = 7,
                ProductID = 29,
                Quantity = 4
            }, new Store_Product
            {
                ID = 267,
                StoreID = 7,
                ProductID = 30,
                Quantity = 4
            }, new Store_Product
            {
                ID = 268,
                StoreID = 7,
                ProductID = 31,
                Quantity = 4
            }, new Store_Product
            {
                ID = 269,
                StoreID = 7,
                ProductID = 32,
                Quantity = 4
            }, new Store_Product
            {
                ID = 270,
                StoreID = 7,
                ProductID = 33,
                Quantity = 4
            }, new Store_Product
            {
                ID = 271,
                StoreID = 7,
                ProductID = 34,
                Quantity = 4
            }, new Store_Product
            {
                ID = 272,
                StoreID = 7,
                ProductID = 35,
                Quantity = 4
            }, new Store_Product
            {
                ID = 273,
                StoreID = 7,
                ProductID = 36,
                Quantity = 4
            }, new Store_Product
            {
                ID = 274,
                StoreID = 7,
                ProductID = 37,
                Quantity = 4
            }, new Store_Product
            {
                ID = 275,
                StoreID = 7,
                ProductID = 38,
                Quantity = 4
            }, new Store_Product
            {
                ID = 276,
                StoreID = 7,
                ProductID = 39,
                Quantity = 4
            }, new Store_Product
            {
                ID = 277,
                StoreID = 7,
                ProductID = 40,
                Quantity = 4
            }, new Store_Product
            {
                ID = 278,
                StoreID = 7,
                ProductID = 41,
                Quantity = 4
            }, new Store_Product
            {
                ID = 279,
                StoreID = 7,
                ProductID = 42,
                Quantity = 4
            }, new Store_Product
            {
                ID = 280,
                StoreID = 7,
                ProductID = 43,
                Quantity = 4
            }, new Store_Product
            {
                ID = 281,
                StoreID = 8,
                ProductID = 1,
                Quantity = 9
            }, new Store_Product
            {
                ID = 282,
                StoreID = 8,
                ProductID = 2,
                Quantity = 9
            }, new Store_Product
            {
                ID = 283,
                StoreID = 8,
                ProductID = 3,
                Quantity = 9
            }, new Store_Product
            {
                ID = 284,
                StoreID = 8,
                ProductID = 4,
                Quantity = 9
            }, new Store_Product
            {
                ID = 285,
                StoreID = 8,
                ProductID = 8,
                Quantity = 9
            }, new Store_Product
            {
                ID = 286,
                StoreID = 8,
                ProductID = 9,
                Quantity = 9
            }, new Store_Product
            {
                ID = 287,
                StoreID = 8,
                ProductID = 10,
                Quantity = 9
            }, new Store_Product
            {
                ID = 288,
                StoreID = 8,
                ProductID = 11,
                Quantity = 9
            }, new Store_Product
            {
                ID = 289,
                StoreID = 8,
                ProductID = 12,
                Quantity = 9
            }, new Store_Product
            {
                ID = 290,
                StoreID = 8,
                ProductID = 13,
                Quantity = 9
            }, new Store_Product
            {
                ID = 291,
                StoreID = 8,
                ProductID = 14,
                Quantity = 9
            }, new Store_Product
            {
                ID = 292,
                StoreID = 8,
                ProductID = 15,
                Quantity = 9
            }, new Store_Product
            {
                ID = 293,
                StoreID = 8,
                ProductID = 16,
                Quantity = 9
            }, new Store_Product
            {
                ID = 294,
                StoreID = 8,
                ProductID = 17,
                Quantity = 9
            }, new Store_Product
            {
                ID = 295,
                StoreID = 8,
                ProductID = 18,
                Quantity = 9
            }, new Store_Product
            {
                ID = 296,
                StoreID = 8,
                ProductID = 19,
                Quantity = 9
            }, new Store_Product
            {
                ID = 297,
                StoreID = 8,
                ProductID = 20,
                Quantity = 9
            }, new Store_Product
            {
                ID = 298,
                StoreID = 8,
                ProductID = 21,
                Quantity = 9
            }, new Store_Product
            {
                ID = 299,
                StoreID = 8,
                ProductID = 22,
                Quantity = 9
            }, new Store_Product
            {
                ID = 300,
                StoreID = 8,
                ProductID = 23,
                Quantity = 9
            }, new Store_Product
            {
                ID = 301,
                StoreID = 8,
                ProductID = 24,
                Quantity = 9
            }, new Store_Product
            {
                ID = 302,
                StoreID = 8,
                ProductID = 25,
                Quantity = 9
            }, new Store_Product
            {
                ID = 303,
                StoreID = 8,
                ProductID = 26,
                Quantity = 9
            }, new Store_Product
            {
                ID = 304,
                StoreID = 8,
                ProductID = 27,
                Quantity = 9
            }, new Store_Product
            {
                ID = 305,
                StoreID = 8,
                ProductID = 28,
                Quantity = 9
            }, new Store_Product
            {
                ID = 306,
                StoreID = 8,
                ProductID = 29,
                Quantity = 9
            }, new Store_Product
            {
                ID = 307,
                StoreID = 8,
                ProductID = 30,
                Quantity = 9
            }, new Store_Product
            {
                ID = 308,
                StoreID = 8,
                ProductID = 31,
                Quantity = 9
            }, new Store_Product
            {
                ID = 309,
                StoreID = 8,
                ProductID = 32,
                Quantity = 9
            }, new Store_Product
            {
                ID = 310,
                StoreID = 8,
                ProductID = 33,
                Quantity = 9
            }, new Store_Product
            {
                ID = 311,
                StoreID = 8,
                ProductID = 34,
                Quantity = 9
            }, new Store_Product
            {
                ID = 312,
                StoreID = 8,
                ProductID = 35,
                Quantity = 9
            }, new Store_Product
            {
                ID = 313,
                StoreID = 8,
                ProductID = 36,
                Quantity = 9
            }, new Store_Product
            {
                ID = 314,
                StoreID = 8,
                ProductID = 37,
                Quantity = 9
            }, new Store_Product
            {
                ID = 315,
                StoreID = 8,
                ProductID = 38,
                Quantity = 9
            }, new Store_Product
            {
                ID = 316,
                StoreID = 8,
                ProductID = 39,
                Quantity = 9
            }, new Store_Product
            {
                ID = 317,
                StoreID = 8,
                ProductID = 40,
                Quantity = 9
            }, new Store_Product
            {
                ID = 318,
                StoreID = 8,
                ProductID = 41,
                Quantity = 9
            }, new Store_Product
            {
                ID = 319,
                StoreID = 8,
                ProductID = 42,
                Quantity = 9
            }, new Store_Product
            {
                ID = 320,
                StoreID = 8,
                ProductID = 43,
                Quantity = 9
            }, new Store_Product
            {
                ID = 321,
                StoreID = 9,
                ProductID = 1,
                Quantity = 7
            }, new Store_Product
            {
                ID = 322,
                StoreID = 9,
                ProductID = 2,
                Quantity = 7
            }, new Store_Product
            {
                ID = 323,
                StoreID = 9,
                ProductID = 3,
                Quantity = 7
            }, new Store_Product
            {
                ID = 324,
                StoreID = 9,
                ProductID = 4,
                Quantity = 7
            }, new Store_Product
            {
                ID = 325,
                StoreID = 9,
                ProductID = 5,
                Quantity = 7
            }, new Store_Product
            {
                ID = 326,
                StoreID = 9,
                ProductID = 9,
                Quantity = 7
            }, new Store_Product
            {
                ID = 327,
                StoreID = 9,
                ProductID = 10,
                Quantity = 7
            }, new Store_Product
            {
                ID = 328,
                StoreID = 9,
                ProductID = 11,
                Quantity = 7
            }, new Store_Product
            {
                ID = 329,
                StoreID = 9,
                ProductID = 12,
                Quantity = 7
            }, new Store_Product
            {
                ID = 330,
                StoreID = 9,
                ProductID = 13,
                Quantity = 7
            }, new Store_Product
            {
                ID = 331,
                StoreID = 9,
                ProductID = 14,
                Quantity = 7
            }, new Store_Product
            {
                ID = 332,
                StoreID = 9,
                ProductID = 15,
                Quantity = 7
            }, new Store_Product
            {
                ID = 333,
                StoreID = 9,
                ProductID = 16,
                Quantity = 7
            }, new Store_Product
            {
                ID = 334,
                StoreID = 9,
                ProductID = 17,
                Quantity = 7
            }, new Store_Product
            {
                ID = 335,
                StoreID = 9,
                ProductID = 18,
                Quantity = 7
            }, new Store_Product
            {
                ID = 336,
                StoreID = 9,
                ProductID = 19,
                Quantity = 7
            }, new Store_Product
            {
                ID = 337,
                StoreID = 9,
                ProductID = 20,
                Quantity = 7
            }, new Store_Product
            {
                ID = 338,
                StoreID = 9,
                ProductID = 21,
                Quantity = 7
            }, new Store_Product
            {
                ID = 339,
                StoreID = 9,
                ProductID = 22,
                Quantity = 7
            }, new Store_Product
            {
                ID = 340,
                StoreID = 9,
                ProductID = 23,
                Quantity = 7
            }, new Store_Product
            {
                ID = 341,
                StoreID = 9,
                ProductID = 24,
                Quantity = 7
            }, new Store_Product
            {
                ID = 342,
                StoreID = 9,
                ProductID = 25,
                Quantity = 7
            }, new Store_Product
            {
                ID = 343,
                StoreID = 9,
                ProductID = 26,
                Quantity = 7
            }, new Store_Product
            {
                ID = 344,
                StoreID = 9,
                ProductID = 27,
                Quantity = 7
            }, new Store_Product
            {
                ID = 345,
                StoreID = 9,
                ProductID = 28,
                Quantity = 7
            }, new Store_Product
            {
                ID = 346,
                StoreID = 9,
                ProductID = 29,
                Quantity = 7
            }, new Store_Product
            {
                ID = 347,
                StoreID = 9,
                ProductID = 30,
                Quantity = 7
            }, new Store_Product
            {
                ID = 348,
                StoreID = 9,
                ProductID = 31,
                Quantity = 7
            }, new Store_Product
            {
                ID = 349,
                StoreID = 9,
                ProductID = 32,
                Quantity = 7
            }, new Store_Product
            {
                ID = 350,
                StoreID = 9,
                ProductID = 33,
                Quantity = 7
            }, new Store_Product
            {
                ID = 351,
                StoreID = 9,
                ProductID = 34,
                Quantity = 7
            }, new Store_Product
            {
                ID = 352,
                StoreID = 9,
                ProductID = 35,
                Quantity = 7
            }, new Store_Product
            {
                ID = 353,
                StoreID = 9,
                ProductID = 36,
                Quantity = 7
            }, new Store_Product
            {
                ID = 354,
                StoreID = 9,
                ProductID = 37,
                Quantity = 7
            }, new Store_Product
            {
                ID = 355,
                StoreID = 9,
                ProductID = 38,
                Quantity = 7
            }, new Store_Product
            {
                ID = 356,
                StoreID = 9,
                ProductID = 39,
                Quantity = 7
            }, new Store_Product
            {
                ID = 357,
                StoreID = 9,
                ProductID = 40,
                Quantity = 7
            }, new Store_Product
            {
                ID = 358,
                StoreID = 9,
                ProductID = 41,
                Quantity = 7
            }, new Store_Product
            {
                ID = 359,
                StoreID = 9,
                ProductID = 42,
                Quantity = 7
            }, new Store_Product
            {
                ID = 360,
                StoreID = 9,
                ProductID = 43,
                Quantity = 7
            }, new Store_Product
            {
                ID = 361,
                StoreID = 10,
                ProductID = 1,
                Quantity = 12
            }, new Store_Product
            {
                ID = 362,
                StoreID = 10,
                ProductID = 2,
                Quantity = 12
            }, new Store_Product
            {
                ID = 363,
                StoreID = 10,
                ProductID = 3,
                Quantity = 12
            }, new Store_Product
            {
                ID = 364,
                StoreID = 10,
                ProductID = 4,
                Quantity = 12
            }, new Store_Product
            {
                ID = 365,
                StoreID = 10,
                ProductID = 5,
                Quantity = 12
            }, new Store_Product
            {
                ID = 366,
                StoreID = 10,
                ProductID = 6,
                Quantity = 12
            }, new Store_Product
            {
                ID = 367,
                StoreID = 10,
                ProductID = 10,
                Quantity = 12
            }, new Store_Product
            {
                ID = 368,
                StoreID = 10,
                ProductID = 11,
                Quantity = 12
            }, new Store_Product
            {
                ID = 369,
                StoreID = 10,
                ProductID = 12,
                Quantity = 12
            }, new Store_Product
            {
                ID = 370,
                StoreID = 10,
                ProductID = 13,
                Quantity = 12
            }, new Store_Product
            {
                ID = 371,
                StoreID = 10,
                ProductID = 14,
                Quantity = 12
            }, new Store_Product
            {
                ID = 372,
                StoreID = 10,
                ProductID = 15,
                Quantity = 12
            }, new Store_Product
            {
                ID = 373,
                StoreID = 10,
                ProductID = 16,
                Quantity = 12
            }, new Store_Product
            {
                ID = 374,
                StoreID = 10,
                ProductID = 17,
                Quantity = 12
            }, new Store_Product
            {
                ID = 375,
                StoreID = 10,
                ProductID = 18,
                Quantity = 12
            }, new Store_Product
            {
                ID = 376,
                StoreID = 10,
                ProductID = 19,
                Quantity = 12
            }, new Store_Product
            {
                ID = 377,
                StoreID = 10,
                ProductID = 20,
                Quantity = 12
            }, new Store_Product
            {
                ID = 378,
                StoreID = 10,
                ProductID = 21,
                Quantity = 12
            }, new Store_Product
            {
                ID = 379,
                StoreID = 10,
                ProductID = 22,
                Quantity = 12
            }, new Store_Product
            {
                ID = 380,
                StoreID = 10,
                ProductID = 23,
                Quantity = 12
            }, new Store_Product
            {
                ID = 381,
                StoreID = 10,
                ProductID = 24,
                Quantity = 12
            }, new Store_Product
            {
                ID = 382,
                StoreID = 10,
                ProductID = 25,
                Quantity = 12
            }, new Store_Product
            {
                ID = 383,
                StoreID = 10,
                ProductID = 26,
                Quantity = 12
            }, new Store_Product
            {
                ID = 384,
                StoreID = 10,
                ProductID = 27,
                Quantity = 12
            }, new Store_Product
            {
                ID = 385,
                StoreID = 10,
                ProductID = 28,
                Quantity = 12
            }, new Store_Product
            {
                ID = 386,
                StoreID = 10,
                ProductID = 29,
                Quantity = 12
            }, new Store_Product
            {
                ID = 387,
                StoreID = 10,
                ProductID = 30,
                Quantity = 12
            }, new Store_Product
            {
                ID = 388,
                StoreID = 10,
                ProductID = 31,
                Quantity = 12
            }, new Store_Product
            {
                ID = 389,
                StoreID = 10,
                ProductID = 32,
                Quantity = 12
            }, new Store_Product
            {
                ID = 390,
                StoreID = 10,
                ProductID = 33,
                Quantity = 12
            }, new Store_Product
            {
                ID = 391,
                StoreID = 10,
                ProductID = 34,
                Quantity = 12
            }, new Store_Product
            {
                ID = 392,
                StoreID = 10,
                ProductID = 35,
                Quantity = 12
            }, new Store_Product
            {
                ID = 393,
                StoreID = 10,
                ProductID = 36,
                Quantity = 12
            }, new Store_Product
            {
                ID = 394,
                StoreID = 10,
                ProductID = 37,
                Quantity = 12
            }, new Store_Product
            {
                ID = 395,
                StoreID = 10,
                ProductID = 38,
                Quantity = 12
            }, new Store_Product
            {
                ID = 396,
                StoreID = 10,
                ProductID = 39,
                Quantity = 12
            }, new Store_Product
            {
                ID = 397,
                StoreID = 10,
                ProductID = 40,
                Quantity = 12
            }, new Store_Product
            {
                ID = 398,
                StoreID = 10,
                ProductID = 41,
                Quantity = 12
            }, new Store_Product
            {
                ID = 399,
                StoreID = 10,
                ProductID = 42,
                Quantity = 12
            }, new Store_Product
            {
                ID = 400,
                StoreID = 10,
                ProductID = 43,
                Quantity = 12
            }, new Store_Product
            {
                ID = 401,
                StoreID = 11,
                ProductID = 1,
                Quantity = 6
            }, new Store_Product
            {
                ID = 402,
                StoreID = 11,
                ProductID = 2,
                Quantity = 6
            }, new Store_Product
            {
                ID = 403,
                StoreID = 11,
                ProductID = 3,
                Quantity = 6
            }, new Store_Product
            {
                ID = 404,
                StoreID = 11,
                ProductID = 4,
                Quantity = 6
            }, new Store_Product
            {
                ID = 405,
                StoreID = 11,
                ProductID = 5,
                Quantity = 6
            }, new Store_Product
            {
                ID = 406,
                StoreID = 11,
                ProductID = 6,
                Quantity = 6
            }, new Store_Product
            {
                ID = 407,
                StoreID = 11,
                ProductID = 7,
                Quantity = 6
            }, new Store_Product
            {
                ID = 408,
                StoreID = 11,
                ProductID = 11,
                Quantity = 6
            }, new Store_Product
            {
                ID = 409,
                StoreID = 11,
                ProductID = 12,
                Quantity = 6
            }, new Store_Product
            {
                ID = 410,
                StoreID = 11,
                ProductID = 13,
                Quantity = 6
            }, new Store_Product
            {
                ID = 411,
                StoreID = 11,
                ProductID = 14,
                Quantity = 6
            }, new Store_Product
            {
                ID = 412,
                StoreID = 11,
                ProductID = 15,
                Quantity = 6
            }, new Store_Product
            {
                ID = 413,
                StoreID = 11,
                ProductID = 16,
                Quantity = 6
            }, new Store_Product
            {
                ID = 414,
                StoreID = 11,
                ProductID = 17,
                Quantity = 6
            }, new Store_Product
            {
                ID = 415,
                StoreID = 11,
                ProductID = 18,
                Quantity = 6
            }, new Store_Product
            {
                ID = 416,
                StoreID = 11,
                ProductID = 19,
                Quantity = 6
            }, new Store_Product
            {
                ID = 417,
                StoreID = 11,
                ProductID = 20,
                Quantity = 6
            }, new Store_Product
            {
                ID = 418,
                StoreID = 11,
                ProductID = 21,
                Quantity = 6
            }, new Store_Product
            {
                ID = 419,
                StoreID = 11,
                ProductID = 22,
                Quantity = 6
            }, new Store_Product
            {
                ID = 420,
                StoreID = 11,
                ProductID = 23,
                Quantity = 6
            }, new Store_Product
            {
                ID = 421,
                StoreID = 11,
                ProductID = 24,
                Quantity = 6
            }, new Store_Product
            {
                ID = 422,
                StoreID = 11,
                ProductID = 25,
                Quantity = 6
            }, new Store_Product
            {
                ID = 423,
                StoreID = 11,
                ProductID = 26,
                Quantity = 6
            }, new Store_Product
            {
                ID = 424,
                StoreID = 11,
                ProductID = 27,
                Quantity = 6
            }, new Store_Product
            {
                ID = 425,
                StoreID = 11,
                ProductID = 28,
                Quantity = 6
            }, new Store_Product
            {
                ID = 426,
                StoreID = 11,
                ProductID = 29,
                Quantity = 6
            }, new Store_Product
            {
                ID = 427,
                StoreID = 11,
                ProductID = 30,
                Quantity = 6
            }, new Store_Product
            {
                ID = 428,
                StoreID = 11,
                ProductID = 31,
                Quantity = 6
            }, new Store_Product
            {
                ID = 429,
                StoreID = 11,
                ProductID = 32,
                Quantity = 6
            }, new Store_Product
            {
                ID = 430,
                StoreID = 11,
                ProductID = 33,
                Quantity = 6
            }, new Store_Product
            {
                ID = 431,
                StoreID = 11,
                ProductID = 34,
                Quantity = 6
            }, new Store_Product
            {
                ID = 432,
                StoreID = 11,
                ProductID = 35,
                Quantity = 6
            }, new Store_Product
            {
                ID = 433,
                StoreID = 11,
                ProductID = 36,
                Quantity = 6
            }, new Store_Product
            {
                ID = 434,
                StoreID = 11,
                ProductID = 37,
                Quantity = 6
            }, new Store_Product
            {
                ID = 435,
                StoreID = 11,
                ProductID = 38,
                Quantity = 6
            }, new Store_Product
            {
                ID = 436,
                StoreID = 11,
                ProductID = 39,
                Quantity = 6
            }, new Store_Product
            {
                ID = 437,
                StoreID = 11,
                ProductID = 40,
                Quantity = 6
            }, new Store_Product
            {
                ID = 438,
                StoreID = 11,
                ProductID = 41,
                Quantity = 6
            }, new Store_Product
            {
                ID = 439,
                StoreID = 11,
                ProductID = 42,
                Quantity = 6
            }, new Store_Product
            {
                ID = 440,
                StoreID = 11,
                ProductID = 43,
                Quantity = 6
            }, new Store_Product
            {
                ID = 441,
                StoreID = 12,
                ProductID = 1,
                Quantity = 15
            }, new Store_Product
            {
                ID = 442,
                StoreID = 12,
                ProductID = 2,
                Quantity = 15
            }, new Store_Product
            {
                ID = 443,
                StoreID = 12,
                ProductID = 3,
                Quantity = 15
            }, new Store_Product
            {
                ID = 444,
                StoreID = 12,
                ProductID = 4,
                Quantity = 15
            }, new Store_Product
            {
                ID = 445,
                StoreID = 12,
                ProductID = 5,
                Quantity = 15
            }, new Store_Product
            {
                ID = 446,
                StoreID = 12,
                ProductID = 6,
                Quantity = 15
            }, new Store_Product
            {
                ID = 447,
                StoreID = 12,
                ProductID = 7,
                Quantity = 15
            }, new Store_Product
            {
                ID = 448,
                StoreID = 12,
                ProductID = 8,
                Quantity = 15
            }, new Store_Product
            {
                ID = 449,
                StoreID = 12,
                ProductID = 12,
                Quantity = 15
            }, new Store_Product
            {
                ID = 450,
                StoreID = 12,
                ProductID = 13,
                Quantity = 15
            }, new Store_Product
            {
                ID = 451,
                StoreID = 12,
                ProductID = 14,
                Quantity = 15
            }, new Store_Product
            {
                ID = 452,
                StoreID = 12,
                ProductID = 15,
                Quantity = 15
            }, new Store_Product
            {
                ID = 453,
                StoreID = 12,
                ProductID = 16,
                Quantity = 15
            }, new Store_Product
            {
                ID = 454,
                StoreID = 12,
                ProductID = 17,
                Quantity = 15
            }, new Store_Product
            {
                ID = 455,
                StoreID = 12,
                ProductID = 18,
                Quantity = 15
            }, new Store_Product
            {
                ID = 456,
                StoreID = 12,
                ProductID = 19,
                Quantity = 15
            }, new Store_Product
            {
                ID = 457,
                StoreID = 12,
                ProductID = 20,
                Quantity = 15
            }, new Store_Product
            {
                ID = 458,
                StoreID = 12,
                ProductID = 21,
                Quantity = 15
            }, new Store_Product
            {
                ID = 459,
                StoreID = 12,
                ProductID = 22,
                Quantity = 15
            }, new Store_Product
            {
                ID = 460,
                StoreID = 12,
                ProductID = 23,
                Quantity = 15
            }, new Store_Product
            {
                ID = 461,
                StoreID = 12,
                ProductID = 24,
                Quantity = 15
            }, new Store_Product
            {
                ID = 462,
                StoreID = 12,
                ProductID = 25,
                Quantity = 15
            }, new Store_Product
            {
                ID = 463,
                StoreID = 12,
                ProductID = 26,
                Quantity = 15
            }, new Store_Product
            {
                ID = 464,
                StoreID = 12,
                ProductID = 27,
                Quantity = 15
            }, new Store_Product
            {
                ID = 465,
                StoreID = 12,
                ProductID = 28,
                Quantity = 15
            }, new Store_Product
            {
                ID = 466,
                StoreID = 12,
                ProductID = 29,
                Quantity = 15
            }, new Store_Product
            {
                ID = 467,
                StoreID = 12,
                ProductID = 30,
                Quantity = 15
            }, new Store_Product
            {
                ID = 468,
                StoreID = 12,
                ProductID = 31,
                Quantity = 15
            }, new Store_Product
            {
                ID = 469,
                StoreID = 12,
                ProductID = 32,
                Quantity = 15
            }, new Store_Product
            {
                ID = 470,
                StoreID = 12,
                ProductID = 33,
                Quantity = 15
            }, new Store_Product
            {
                ID = 471,
                StoreID = 12,
                ProductID = 34,
                Quantity = 15
            }, new Store_Product
            {
                ID = 472,
                StoreID = 12,
                ProductID = 35,
                Quantity = 15
            }, new Store_Product
            {
                ID = 473,
                StoreID = 12,
                ProductID = 36,
                Quantity = 15
            }, new Store_Product
            {
                ID = 474,
                StoreID = 12,
                ProductID = 37,
                Quantity = 15
            }, new Store_Product
            {
                ID = 475,
                StoreID = 12,
                ProductID = 38,
                Quantity = 15
            }, new Store_Product
            {
                ID = 476,
                StoreID = 12,
                ProductID = 39,
                Quantity = 15
            }, new Store_Product
            {
                ID = 477,
                StoreID = 12,
                ProductID = 40,
                Quantity = 15
            }, new Store_Product
            {
                ID = 478,
                StoreID = 12,
                ProductID = 41,
                Quantity = 15
            }, new Store_Product
            {
                ID = 479,
                StoreID = 12,
                ProductID = 42,
                Quantity = 15
            }, new Store_Product
            {
                ID = 480,
                StoreID = 12,
                ProductID = 43,
                Quantity = 15
            }, new Store_Product
            {
                ID = 481,
                StoreID = 13,
                ProductID = 1,
                Quantity = 10
            }, new Store_Product
            {
                ID = 482,
                StoreID = 13,
                ProductID = 2,
                Quantity = 10
            }, new Store_Product
            {
                ID = 483,
                StoreID = 13,
                ProductID = 3,
                Quantity = 10
            }, new Store_Product
            {
                ID = 484,
                StoreID = 13,
                ProductID = 4,
                Quantity = 10
            }, new Store_Product
            {
                ID = 485,
                StoreID = 13,
                ProductID = 5,
                Quantity = 10
            }, new Store_Product
            {
                ID = 486,
                StoreID = 13,
                ProductID = 6,
                Quantity = 10
            }, new Store_Product
            {
                ID = 487,
                StoreID = 13,
                ProductID = 7,
                Quantity = 10
            }, new Store_Product
            {
                ID = 488,
                StoreID = 13,
                ProductID = 8,
                Quantity = 10
            }, new Store_Product
            {
                ID = 489,
                StoreID = 13,
                ProductID = 9,
                Quantity = 10
            }, new Store_Product
            {
                ID = 490,
                StoreID = 13,
                ProductID = 13,
                Quantity = 10
            }, new Store_Product
            {
                ID = 491,
                StoreID = 13,
                ProductID = 14,
                Quantity = 10
            }, new Store_Product
            {
                ID = 492,
                StoreID = 13,
                ProductID = 15,
                Quantity = 10
            }, new Store_Product
            {
                ID = 493,
                StoreID = 13,
                ProductID = 16,
                Quantity = 10
            }, new Store_Product
            {
                ID = 494,
                StoreID = 13,
                ProductID = 17,
                Quantity = 10
            }, new Store_Product
            {
                ID = 495,
                StoreID = 13,
                ProductID = 18,
                Quantity = 10
            }, new Store_Product
            {
                ID = 496,
                StoreID = 13,
                ProductID = 19,
                Quantity = 10
            }, new Store_Product
            {
                ID = 497,
                StoreID = 13,
                ProductID = 20,
                Quantity = 10
            }, new Store_Product
            {
                ID = 498,
                StoreID = 13,
                ProductID = 21,
                Quantity = 10
            }, new Store_Product
            {
                ID = 499,
                StoreID = 13,
                ProductID = 22,
                Quantity = 10
            }, new Store_Product
            {
                ID = 500,
                StoreID = 13,
                ProductID = 23,
                Quantity = 10
            }, new Store_Product
            {
                ID = 501,
                StoreID = 13,
                ProductID = 24,
                Quantity = 10
            }, new Store_Product
            {
                ID = 502,
                StoreID = 13,
                ProductID = 25,
                Quantity = 10
            }, new Store_Product
            {
                ID = 503,
                StoreID = 13,
                ProductID = 26,
                Quantity = 10
            }, new Store_Product
            {
                ID = 504,
                StoreID = 13,
                ProductID = 27,
                Quantity = 10
            }, new Store_Product
            {
                ID = 505,
                StoreID = 13,
                ProductID = 28,
                Quantity = 10
            }, new Store_Product
            {
                ID = 506,
                StoreID = 13,
                ProductID = 29,
                Quantity = 10
            }, new Store_Product
            {
                ID = 507,
                StoreID = 13,
                ProductID = 30,
                Quantity = 10
            }, new Store_Product
            {
                ID = 508,
                StoreID = 13,
                ProductID = 31,
                Quantity = 10
            }, new Store_Product
            {
                ID = 509,
                StoreID = 13,
                ProductID = 32,
                Quantity = 10
            }, new Store_Product
            {
                ID = 510,
                StoreID = 13,
                ProductID = 33,
                Quantity = 10
            }, new Store_Product
            {
                ID = 511,
                StoreID = 13,
                ProductID = 34,
                Quantity = 10
            }, new Store_Product
            {
                ID = 512,
                StoreID = 13,
                ProductID = 35,
                Quantity = 10
            }, new Store_Product
            {
                ID = 513,
                StoreID = 13,
                ProductID = 36,
                Quantity = 10
            }, new Store_Product
            {
                ID = 514,
                StoreID = 13,
                ProductID = 37,
                Quantity = 10
            }, new Store_Product
            {
                ID = 515,
                StoreID = 13,
                ProductID = 38,
                Quantity = 10
            }, new Store_Product
            {
                ID = 516,
                StoreID = 13,
                ProductID = 39,
                Quantity = 10
            }, new Store_Product
            {
                ID = 517,
                StoreID = 13,
                ProductID = 40,
                Quantity = 10
            }, new Store_Product
            {
                ID = 518,
                StoreID = 13,
                ProductID = 41,
                Quantity = 10
            }, new Store_Product
            {
                ID = 519,
                StoreID = 13,
                ProductID = 42,
                Quantity = 10
            }, new Store_Product
            {
                ID = 520,
                StoreID = 13,
                ProductID = 43,
                Quantity = 10
            }, new Store_Product
            {
                ID = 521,
                StoreID = 14,
                ProductID = 1,
                Quantity = 6
            }, new Store_Product
            {
                ID = 522,
                StoreID = 14,
                ProductID = 2,
                Quantity = 6
            }, new Store_Product
            {
                ID = 523,
                StoreID = 14,
                ProductID = 3,
                Quantity = 6
            }, new Store_Product
            {
                ID = 524,
                StoreID = 14,
                ProductID = 4,
                Quantity = 6
            }, new Store_Product
            {
                ID = 525,
                StoreID = 14,
                ProductID = 5,
                Quantity = 6
            }, new Store_Product
            {
                ID = 526,
                StoreID = 14,
                ProductID = 6,
                Quantity = 6
            }, new Store_Product
            {
                ID = 527,
                StoreID = 14,
                ProductID = 7,
                Quantity = 6
            }, new Store_Product
            {
                ID = 528,
                StoreID = 14,
                ProductID = 8,
                Quantity = 6
            }, new Store_Product
            {
                ID = 529,
                StoreID = 14,
                ProductID = 9,
                Quantity = 6
            }, new Store_Product
            {
                ID = 530,
                StoreID = 14,
                ProductID = 10,
                Quantity = 6
            }, new Store_Product
            {
                ID = 531,
                StoreID = 14,
                ProductID = 14,
                Quantity = 6
            }, new Store_Product
            {
                ID = 532,
                StoreID = 14,
                ProductID = 15,
                Quantity = 6
            }, new Store_Product
            {
                ID = 533,
                StoreID = 14,
                ProductID = 16,
                Quantity = 6
            }, new Store_Product
            {
                ID = 534,
                StoreID = 14,
                ProductID = 17,
                Quantity = 6
            }, new Store_Product
            {
                ID = 535,
                StoreID = 14,
                ProductID = 18,
                Quantity = 6
            }, new Store_Product
            {
                ID = 536,
                StoreID = 14,
                ProductID = 19,
                Quantity = 6
            }, new Store_Product
            {
                ID = 537,
                StoreID = 14,
                ProductID = 20,
                Quantity = 6
            }, new Store_Product
            {
                ID = 538,
                StoreID = 14,
                ProductID = 21,
                Quantity = 6
            }, new Store_Product
            {
                ID = 539,
                StoreID = 14,
                ProductID = 22,
                Quantity = 6
            }, new Store_Product
            {
                ID = 540,
                StoreID = 14,
                ProductID = 23,
                Quantity = 6
            }, new Store_Product
            {
                ID = 541,
                StoreID = 14,
                ProductID = 24,
                Quantity = 6
            }, new Store_Product
            {
                ID = 542,
                StoreID = 14,
                ProductID = 25,
                Quantity = 6
            }, new Store_Product
            {
                ID = 543,
                StoreID = 14,
                ProductID = 26,
                Quantity = 6
            }, new Store_Product
            {
                ID = 544,
                StoreID = 14,
                ProductID = 27,
                Quantity = 6
            }, new Store_Product
            {
                ID = 545,
                StoreID = 14,
                ProductID = 28,
                Quantity = 6
            }, new Store_Product
            {
                ID = 546,
                StoreID = 14,
                ProductID = 29,
                Quantity = 6
            }, new Store_Product
            {
                ID = 547,
                StoreID = 14,
                ProductID = 30,
                Quantity = 6
            }, new Store_Product
            {
                ID = 548,
                StoreID = 14,
                ProductID = 31,
                Quantity = 6
            }, new Store_Product
            {
                ID = 549,
                StoreID = 14,
                ProductID = 32,
                Quantity = 6
            }, new Store_Product
            {
                ID = 550,
                StoreID = 14,
                ProductID = 33,
                Quantity = 6
            }, new Store_Product
            {
                ID = 551,
                StoreID = 14,
                ProductID = 34,
                Quantity = 6
            }, new Store_Product
            {
                ID = 552,
                StoreID = 14,
                ProductID = 35,
                Quantity = 6
            }, new Store_Product
            {
                ID = 553,
                StoreID = 14,
                ProductID = 36,
                Quantity = 6
            }, new Store_Product
            {
                ID = 554,
                StoreID = 14,
                ProductID = 37,
                Quantity = 6
            }, new Store_Product
            {
                ID = 555,
                StoreID = 14,
                ProductID = 38,
                Quantity = 6
            }, new Store_Product
            {
                ID = 556,
                StoreID = 14,
                ProductID = 39,
                Quantity = 6
            }, new Store_Product
            {
                ID = 557,
                StoreID = 14,
                ProductID = 40,
                Quantity = 6
            }, new Store_Product
            {
                ID = 558,
                StoreID = 14,
                ProductID = 41,
                Quantity = 6
            }, new Store_Product
            {
                ID = 559,
                StoreID = 14,
                ProductID = 42,
                Quantity = 6
            }, new Store_Product
            {
                ID = 560,
                StoreID = 14,
                ProductID = 43,
                Quantity = 6
            }, new Store_Product
            {
                ID = 561,
                StoreID = 15,
                ProductID = 1,
                Quantity = 20
            }, new Store_Product
            {
                ID = 562,
                StoreID = 15,
                ProductID = 2,
                Quantity = 20
            }, new Store_Product
            {
                ID = 563,
                StoreID = 15,
                ProductID = 3,
                Quantity = 20
            }, new Store_Product
            {
                ID = 564,
                StoreID = 15,
                ProductID = 4,
                Quantity = 20
            }, new Store_Product
            {
                ID = 565,
                StoreID = 15,
                ProductID = 5,
                Quantity = 20
            }, new Store_Product
            {
                ID = 566,
                StoreID = 15,
                ProductID = 6,
                Quantity = 20
            }, new Store_Product
            {
                ID = 567,
                StoreID = 15,
                ProductID = 7,
                Quantity = 20
            }, new Store_Product
            {
                ID = 568,
                StoreID = 15,
                ProductID = 8,
                Quantity = 20
            }, new Store_Product
            {
                ID = 569,
                StoreID = 15,
                ProductID = 9,
                Quantity = 20
            }, new Store_Product
            {
                ID = 570,
                StoreID = 15,
                ProductID = 10,
                Quantity = 20
            }, new Store_Product
            {
                ID = 571,
                StoreID = 15,
                ProductID = 11,
                Quantity = 20
            }, new Store_Product
            {
                ID = 572,
                StoreID = 15,
                ProductID = 15,
                Quantity = 20
            }, new Store_Product
            {
                ID = 573,
                StoreID = 15,
                ProductID = 16,
                Quantity = 20
            }, new Store_Product
            {
                ID = 574,
                StoreID = 15,
                ProductID = 17,
                Quantity = 20
            }, new Store_Product
            {
                ID = 575,
                StoreID = 15,
                ProductID = 18,
                Quantity = 20
            }, new Store_Product
            {
                ID = 576,
                StoreID = 15,
                ProductID = 19,
                Quantity = 20
            }, new Store_Product
            {
                ID = 577,
                StoreID = 15,
                ProductID = 20,
                Quantity = 20
            }, new Store_Product
            {
                ID = 578,
                StoreID = 15,
                ProductID = 21,
                Quantity = 20
            }, new Store_Product
            {
                ID = 579,
                StoreID = 15,
                ProductID = 22,
                Quantity = 20
            }, new Store_Product
            {
                ID = 580,
                StoreID = 15,
                ProductID = 23,
                Quantity = 20
            }, new Store_Product
            {
                ID = 581,
                StoreID = 15,
                ProductID = 24,
                Quantity = 20
            }, new Store_Product
            {
                ID = 582,
                StoreID = 15,
                ProductID = 25,
                Quantity = 20
            }, new Store_Product
            {
                ID = 583,
                StoreID = 15,
                ProductID = 26,
                Quantity = 20
            }, new Store_Product
            {
                ID = 584,
                StoreID = 15,
                ProductID = 27,
                Quantity = 20
            }, new Store_Product
            {
                ID = 585,
                StoreID = 15,
                ProductID = 28,
                Quantity = 20
            }, new Store_Product
            {
                ID = 586,
                StoreID = 15,
                ProductID = 29,
                Quantity = 20
            }, new Store_Product
            {
                ID = 587,
                StoreID = 15,
                ProductID = 30,
                Quantity = 20
            }, new Store_Product
            {
                ID = 588,
                StoreID = 15,
                ProductID = 31,
                Quantity = 20
            }, new Store_Product
            {
                ID = 589,
                StoreID = 15,
                ProductID = 32,
                Quantity = 20
            }, new Store_Product
            {
                ID = 590,
                StoreID = 15,
                ProductID = 33,
                Quantity = 20
            }, new Store_Product
            {
                ID = 591,
                StoreID = 15,
                ProductID = 34,
                Quantity = 20
            }, new Store_Product
            {
                ID = 592,
                StoreID = 15,
                ProductID = 35,
                Quantity = 20
            }, new Store_Product
            {
                ID = 593,
                StoreID = 15,
                ProductID = 36,
                Quantity = 20
            }, new Store_Product
            {
                ID = 594,
                StoreID = 15,
                ProductID = 37,
                Quantity = 20
            }, new Store_Product
            {
                ID = 595,
                StoreID = 15,
                ProductID = 38,
                Quantity = 20
            }, new Store_Product
            {
                ID = 596,
                StoreID = 15,
                ProductID = 39,
                Quantity = 20
            }, new Store_Product
            {
                ID = 597,
                StoreID = 15,
                ProductID = 40,
                Quantity = 20
            }, new Store_Product
            {
                ID = 598,
                StoreID = 15,
                ProductID = 41,
                Quantity = 20
            }, new Store_Product
            {
                ID = 599,
                StoreID = 15,
                ProductID = 42,
                Quantity = 20
            }, new Store_Product
            {
                ID = 600,
                StoreID = 15,
                ProductID = 43,
                Quantity = 20
            }, new Store_Product
            {
                ID = 601,
                StoreID = 16,
                ProductID = 1,
                Quantity = 12
            }, new Store_Product
            {
                ID = 602,
                StoreID = 16,
                ProductID = 2,
                Quantity = 12
            }, new Store_Product
            {
                ID = 603,
                StoreID = 16,
                ProductID = 3,
                Quantity = 12
            }, new Store_Product
            {
                ID = 604,
                StoreID = 16,
                ProductID = 4,
                Quantity = 12
            }, new Store_Product
            {
                ID = 605,
                StoreID = 16,
                ProductID = 5,
                Quantity = 12
            }, new Store_Product
            {
                ID = 606,
                StoreID = 16,
                ProductID = 6,
                Quantity = 12
            }, new Store_Product
            {
                ID = 607,
                StoreID = 16,
                ProductID = 7,
                Quantity = 12
            }, new Store_Product
            {
                ID = 608,
                StoreID = 16,
                ProductID = 8,
                Quantity = 12
            }, new Store_Product
            {
                ID = 609,
                StoreID = 16,
                ProductID = 9,
                Quantity = 12
            }, new Store_Product
            {
                ID = 610,
                StoreID = 16,
                ProductID = 10,
                Quantity = 12
            }, new Store_Product
            {
                ID = 611,
                StoreID = 16,
                ProductID = 11,
                Quantity = 12
            }, new Store_Product
            {
                ID = 612,
                StoreID = 16,
                ProductID = 12,
                Quantity = 12
            }, new Store_Product
            {
                ID = 613,
                StoreID = 16,
                ProductID = 16,
                Quantity = 12
            }, new Store_Product
            {
                ID = 614,
                StoreID = 16,
                ProductID = 17,
                Quantity = 12
            }, new Store_Product
            {
                ID = 615,
                StoreID = 16,
                ProductID = 18,
                Quantity = 12
            }, new Store_Product
            {
                ID = 616,
                StoreID = 16,
                ProductID = 19,
                Quantity = 12
            }, new Store_Product
            {
                ID = 617,
                StoreID = 16,
                ProductID = 20,
                Quantity = 12
            }, new Store_Product
            {
                ID = 618,
                StoreID = 16,
                ProductID = 21,
                Quantity = 12
            }, new Store_Product
            {
                ID = 619,
                StoreID = 16,
                ProductID = 22,
                Quantity = 12
            }, new Store_Product
            {
                ID = 620,
                StoreID = 16,
                ProductID = 23,
                Quantity = 12
            }, new Store_Product
            {
                ID = 621,
                StoreID = 16,
                ProductID = 24,
                Quantity = 12
            }, new Store_Product
            {
                ID = 622,
                StoreID = 16,
                ProductID = 25,
                Quantity = 12
            }, new Store_Product
            {
                ID = 623,
                StoreID = 16,
                ProductID = 26,
                Quantity = 12
            }, new Store_Product
            {
                ID = 624,
                StoreID = 16,
                ProductID = 27,
                Quantity = 12
            }, new Store_Product
            {
                ID = 625,
                StoreID = 16,
                ProductID = 28,
                Quantity = 12
            }, new Store_Product
            {
                ID = 626,
                StoreID = 16,
                ProductID = 29,
                Quantity = 12
            }, new Store_Product
            {
                ID = 627,
                StoreID = 16,
                ProductID = 30,
                Quantity = 12
            }, new Store_Product
            {
                ID = 628,
                StoreID = 16,
                ProductID = 31,
                Quantity = 12
            }, new Store_Product
            {
                ID = 629,
                StoreID = 16,
                ProductID = 32,
                Quantity = 12
            }, new Store_Product
            {
                ID = 630,
                StoreID = 16,
                ProductID = 33,
                Quantity = 12
            }, new Store_Product
            {
                ID = 631,
                StoreID = 16,
                ProductID = 34,
                Quantity = 12
            }, new Store_Product
            {
                ID = 632,
                StoreID = 16,
                ProductID = 35,
                Quantity = 12
            }, new Store_Product
            {
                ID = 633,
                StoreID = 16,
                ProductID = 36,
                Quantity = 12
            }, new Store_Product
            {
                ID = 634,
                StoreID = 16,
                ProductID = 37,
                Quantity = 12
            }, new Store_Product
            {
                ID = 635,
                StoreID = 16,
                ProductID = 38,
                Quantity = 12
            }, new Store_Product
            {
                ID = 636,
                StoreID = 16,
                ProductID = 39,
                Quantity = 12
            }, new Store_Product
            {
                ID = 637,
                StoreID = 16,
                ProductID = 40,
                Quantity = 12
            }, new Store_Product
            {
                ID = 638,
                StoreID = 16,
                ProductID = 41,
                Quantity = 12
            }, new Store_Product
            {
                ID = 639,
                StoreID = 16,
                ProductID = 42,
                Quantity = 12
            }, new Store_Product
            {
                ID = 640,
                StoreID = 16,
                ProductID = 43,
                Quantity = 12
            }, new Store_Product
            {
                ID = 641,
                StoreID = 17,
                ProductID = 1,
                Quantity = 8
            }, new Store_Product
            {
                ID = 642,
                StoreID = 17,
                ProductID = 2,
                Quantity = 8
            }, new Store_Product
            {
                ID = 643,
                StoreID = 17,
                ProductID = 3,
                Quantity = 8
            }, new Store_Product
            {
                ID = 644,
                StoreID = 17,
                ProductID = 4,
                Quantity = 8
            }, new Store_Product
            {
                ID = 645,
                StoreID = 17,
                ProductID = 5,
                Quantity = 8
            }, new Store_Product
            {
                ID = 646,
                StoreID = 17,
                ProductID = 6,
                Quantity = 8
            }, new Store_Product
            {
                ID = 647,
                StoreID = 17,
                ProductID = 7,
                Quantity = 8
            }, new Store_Product
            {
                ID = 648,
                StoreID = 17,
                ProductID = 8,
                Quantity = 8
            }, new Store_Product
            {
                ID = 649,
                StoreID = 17,
                ProductID = 9,
                Quantity = 8
            }, new Store_Product
            {
                ID = 650,
                StoreID = 17,
                ProductID = 10,
                Quantity = 8
            }, new Store_Product
            {
                ID = 651,
                StoreID = 17,
                ProductID = 11,
                Quantity = 8
            }, new Store_Product
            {
                ID = 652,
                StoreID = 17,
                ProductID = 12,
                Quantity = 8
            }, new Store_Product
            {
                ID = 653,
                StoreID = 17,
                ProductID = 13,
                Quantity = 8
            }, new Store_Product
            {
                ID = 654,
                StoreID = 17,
                ProductID = 17,
                Quantity = 8
            }, new Store_Product
            {
                ID = 655,
                StoreID = 17,
                ProductID = 18,
                Quantity = 8
            }, new Store_Product
            {
                ID = 656,
                StoreID = 17,
                ProductID = 19,
                Quantity = 8
            }, new Store_Product
            {
                ID = 657,
                StoreID = 17,
                ProductID = 20,
                Quantity = 8
            }, new Store_Product
            {
                ID = 658,
                StoreID = 17,
                ProductID = 21,
                Quantity = 8
            }, new Store_Product
            {
                ID = 659,
                StoreID = 17,
                ProductID = 22,
                Quantity = 8
            }, new Store_Product
            {
                ID = 660,
                StoreID = 17,
                ProductID = 23,
                Quantity = 8
            }, new Store_Product
            {
                ID = 661,
                StoreID = 17,
                ProductID = 24,
                Quantity = 8
            }, new Store_Product
            {
                ID = 662,
                StoreID = 17,
                ProductID = 25,
                Quantity = 8
            }, new Store_Product
            {
                ID = 663,
                StoreID = 17,
                ProductID = 26,
                Quantity = 8
            }, new Store_Product
            {
                ID = 664,
                StoreID = 17,
                ProductID = 27,
                Quantity = 8
            }, new Store_Product
            {
                ID = 665,
                StoreID = 17,
                ProductID = 28,
                Quantity = 8
            }, new Store_Product
            {
                ID = 666,
                StoreID = 17,
                ProductID = 29,
                Quantity = 8
            }, new Store_Product
            {
                ID = 667,
                StoreID = 17,
                ProductID = 30,
                Quantity = 8
            }, new Store_Product
            {
                ID = 668,
                StoreID = 17,
                ProductID = 31,
                Quantity = 8
            }, new Store_Product
            {
                ID = 669,
                StoreID = 17,
                ProductID = 32,
                Quantity = 8
            }, new Store_Product
            {
                ID = 670,
                StoreID = 17,
                ProductID = 33,
                Quantity = 8
            }, new Store_Product
            {
                ID = 671,
                StoreID = 17,
                ProductID = 34,
                Quantity = 8
            }, new Store_Product
            {
                ID = 672,
                StoreID = 17,
                ProductID = 35,
                Quantity = 8
            }, new Store_Product
            {
                ID = 673,
                StoreID = 17,
                ProductID = 36,
                Quantity = 8
            }, new Store_Product
            {
                ID = 674,
                StoreID = 17,
                ProductID = 37,
                Quantity = 8
            }, new Store_Product
            {
                ID = 675,
                StoreID = 17,
                ProductID = 38,
                Quantity = 8
            }, new Store_Product
            {
                ID = 676,
                StoreID = 17,
                ProductID = 39,
                Quantity = 8
            }, new Store_Product
            {
                ID = 677,
                StoreID = 17,
                ProductID = 40,
                Quantity = 8
            }, new Store_Product
            {
                ID = 678,
                StoreID = 17,
                ProductID = 41,
                Quantity = 8
            }, new Store_Product
            {
                ID = 679,
                StoreID = 17,
                ProductID = 42,
                Quantity = 8
            }, new Store_Product
            {
                ID = 680,
                StoreID = 17,
                ProductID = 43,
                Quantity = 8
            }, new Store_Product
            {
                ID = 681,
                StoreID = 18,
                ProductID = 1,
                Quantity = 8
            }, new Store_Product
            {
                ID = 682,
                StoreID = 18,
                ProductID = 2,
                Quantity = 8
            }, new Store_Product
            {
                ID = 683,
                StoreID = 18,
                ProductID = 3,
                Quantity = 8
            }, new Store_Product
            {
                ID = 684,
                StoreID = 18,
                ProductID = 4,
                Quantity = 8
            }, new Store_Product
            {
                ID = 685,
                StoreID = 18,
                ProductID = 5,
                Quantity = 8
            }, new Store_Product
            {
                ID = 686,
                StoreID = 18,
                ProductID = 6,
                Quantity = 8
            }, new Store_Product
            {
                ID = 687,
                StoreID = 18,
                ProductID = 7,
                Quantity = 8
            }, new Store_Product
            {
                ID = 688,
                StoreID = 18,
                ProductID = 8,
                Quantity = 8
            }, new Store_Product
            {
                ID = 689,
                StoreID = 18,
                ProductID = 9,
                Quantity = 8
            }, new Store_Product
            {
                ID = 690,
                StoreID = 18,
                ProductID = 10,
                Quantity = 8
            }, new Store_Product
            {
                ID = 691,
                StoreID = 18,
                ProductID = 11,
                Quantity = 8
            }, new Store_Product
            {
                ID = 692,
                StoreID = 18,
                ProductID = 12,
                Quantity = 8
            }, new Store_Product
            {
                ID = 693,
                StoreID = 18,
                ProductID = 13,
                Quantity = 8
            }, new Store_Product
            {
                ID = 694,
                StoreID = 18,
                ProductID = 14,
                Quantity = 8
            }, new Store_Product
            {
                ID = 695,
                StoreID = 18,
                ProductID = 18,
                Quantity = 8
            }, new Store_Product
            {
                ID = 696,
                StoreID = 18,
                ProductID = 19,
                Quantity = 8
            }, new Store_Product
            {
                ID = 697,
                StoreID = 18,
                ProductID = 20,
                Quantity = 8
            }, new Store_Product
            {
                ID = 698,
                StoreID = 18,
                ProductID = 21,
                Quantity = 8
            }, new Store_Product
            {
                ID = 699,
                StoreID = 18,
                ProductID = 22,
                Quantity = 8
            }, new Store_Product
            {
                ID = 700,
                StoreID = 18,
                ProductID = 23,
                Quantity = 8
            }, new Store_Product
            {
                ID = 701,
                StoreID = 18,
                ProductID = 24,
                Quantity = 8
            }, new Store_Product
            {
                ID = 702,
                StoreID = 18,
                ProductID = 25,
                Quantity = 8
            }, new Store_Product
            {
                ID = 703,
                StoreID = 18,
                ProductID = 26,
                Quantity = 8
            }, new Store_Product
            {
                ID = 704,
                StoreID = 18,
                ProductID = 27,
                Quantity = 8
            }, new Store_Product
            {
                ID = 705,
                StoreID = 18,
                ProductID = 28,
                Quantity = 8
            }, new Store_Product
            {
                ID = 706,
                StoreID = 18,
                ProductID = 29,
                Quantity = 8
            }, new Store_Product
            {
                ID = 707,
                StoreID = 18,
                ProductID = 30,
                Quantity = 8
            }, new Store_Product
            {
                ID = 708,
                StoreID = 18,
                ProductID = 31,
                Quantity = 8
            }, new Store_Product
            {
                ID = 709,
                StoreID = 18,
                ProductID = 32,
                Quantity = 8
            }, new Store_Product
            {
                ID = 710,
                StoreID = 18,
                ProductID = 33,
                Quantity = 8
            }, new Store_Product
            {
                ID = 711,
                StoreID = 18,
                ProductID = 34,
                Quantity = 8
            }, new Store_Product
            {
                ID = 712,
                StoreID = 18,
                ProductID = 35,
                Quantity = 8
            }, new Store_Product
            {
                ID = 713,
                StoreID = 18,
                ProductID = 36,
                Quantity = 8
            }, new Store_Product
            {
                ID = 714,
                StoreID = 18,
                ProductID = 37,
                Quantity = 8
            }, new Store_Product
            {
                ID = 715,
                StoreID = 18,
                ProductID = 38,
                Quantity = 8
            }, new Store_Product
            {
                ID = 716,
                StoreID = 18,
                ProductID = 39,
                Quantity = 8
            }, new Store_Product
            {
                ID = 717,
                StoreID = 18,
                ProductID = 40,
                Quantity = 8
            }, new Store_Product
            {
                ID = 718,
                StoreID = 18,
                ProductID = 41,
                Quantity = 8
            }, new Store_Product
            {
                ID = 719,
                StoreID = 18,
                ProductID = 42,
                Quantity = 8
            }, new Store_Product
            {
                ID = 720,
                StoreID = 18,
                ProductID = 43,
                Quantity = 8
            }, new Store_Product
            {
                ID = 721,
                StoreID = 19,
                ProductID = 1,
                Quantity = 10
            }, new Store_Product
            {
                ID = 722,
                StoreID = 19,
                ProductID = 2,
                Quantity = 10
            }, new Store_Product
            {
                ID = 723,
                StoreID = 19,
                ProductID = 3,
                Quantity = 10
            }, new Store_Product
            {
                ID = 724,
                StoreID = 19,
                ProductID = 4,
                Quantity = 10
            }, new Store_Product
            {
                ID = 725,
                StoreID = 19,
                ProductID = 5,
                Quantity = 10
            }, new Store_Product
            {
                ID = 726,
                StoreID = 19,
                ProductID = 6,
                Quantity = 10
            }, new Store_Product
            {
                ID = 727,
                StoreID = 19,
                ProductID = 7,
                Quantity = 10
            }, new Store_Product
            {
                ID = 728,
                StoreID = 19,
                ProductID = 8,
                Quantity = 10
            }, new Store_Product
            {
                ID = 729,
                StoreID = 19,
                ProductID = 9,
                Quantity = 10
            }, new Store_Product
            {
                ID = 730,
                StoreID = 19,
                ProductID = 10,
                Quantity = 10
            }, new Store_Product
            {
                ID = 731,
                StoreID = 19,
                ProductID = 11,
                Quantity = 10
            }, new Store_Product
            {
                ID = 732,
                StoreID = 19,
                ProductID = 12,
                Quantity = 10
            }, new Store_Product
            {
                ID = 733,
                StoreID = 19,
                ProductID = 13,
                Quantity = 10
            }, new Store_Product
            {
                ID = 734,
                StoreID = 19,
                ProductID = 14,
                Quantity = 10
            }, new Store_Product
            {
                ID = 735,
                StoreID = 19,
                ProductID = 15,
                Quantity = 10
            }, new Store_Product
            {
                ID = 736,
                StoreID = 19,
                ProductID = 19,
                Quantity = 10
            }, new Store_Product
            {
                ID = 737,
                StoreID = 19,
                ProductID = 20,
                Quantity = 10
            }, new Store_Product
            {
                ID = 738,
                StoreID = 19,
                ProductID = 21,
                Quantity = 10
            }, new Store_Product
            {
                ID = 739,
                StoreID = 19,
                ProductID = 22,
                Quantity = 10
            }, new Store_Product
            {
                ID = 740,
                StoreID = 19,
                ProductID = 23,
                Quantity = 10
            }, new Store_Product
            {
                ID = 741,
                StoreID = 19,
                ProductID = 24,
                Quantity = 10
            }, new Store_Product
            {
                ID = 742,
                StoreID = 19,
                ProductID = 25,
                Quantity = 10
            }, new Store_Product
            {
                ID = 743,
                StoreID = 19,
                ProductID = 26,
                Quantity = 10
            }, new Store_Product
            {
                ID = 744,
                StoreID = 19,
                ProductID = 27,
                Quantity = 10
            }, new Store_Product
            {
                ID = 745,
                StoreID = 19,
                ProductID = 28,
                Quantity = 10
            }, new Store_Product
            {
                ID = 746,
                StoreID = 19,
                ProductID = 29,
                Quantity = 10
            }, new Store_Product
            {
                ID = 747,
                StoreID = 19,
                ProductID = 30,
                Quantity = 10
            }, new Store_Product
            {
                ID = 748,
                StoreID = 19,
                ProductID = 31,
                Quantity = 10
            }, new Store_Product
            {
                ID = 749,
                StoreID = 19,
                ProductID = 32,
                Quantity = 10
            }, new Store_Product
            {
                ID = 750,
                StoreID = 19,
                ProductID = 33,
                Quantity = 10
            }, new Store_Product
            {
                ID = 751,
                StoreID = 19,
                ProductID = 34,
                Quantity = 10
            }, new Store_Product
            {
                ID = 752,
                StoreID = 19,
                ProductID = 35,
                Quantity = 10
            }, new Store_Product
            {
                ID = 753,
                StoreID = 19,
                ProductID = 36,
                Quantity = 10
            }, new Store_Product
            {
                ID = 754,
                StoreID = 19,
                ProductID = 37,
                Quantity = 10
            }, new Store_Product
            {
                ID = 755,
                StoreID = 19,
                ProductID = 38,
                Quantity = 10
            }, new Store_Product
            {
                ID = 756,
                StoreID = 19,
                ProductID = 39,
                Quantity = 10
            }, new Store_Product
            {
                ID = 757,
                StoreID = 19,
                ProductID = 40,
                Quantity = 10
            }, new Store_Product
            {
                ID = 758,
                StoreID = 19,
                ProductID = 41,
                Quantity = 10
            }, new Store_Product
            {
                ID = 759,
                StoreID = 19,
                ProductID = 42,
                Quantity = 10
            }, new Store_Product
            {
                ID = 760,
                StoreID = 19,
                ProductID = 43,
                Quantity = 10
            }, new Store_Product
            {
                ID = 761,
                StoreID = 20,
                ProductID = 1,
                Quantity = 18
            }, new Store_Product
            {
                ID = 762,
                StoreID = 20,
                ProductID = 2,
                Quantity = 18
            }, new Store_Product
            {
                ID = 763,
                StoreID = 20,
                ProductID = 3,
                Quantity = 18
            }, new Store_Product
            {
                ID = 764,
                StoreID = 20,
                ProductID = 4,
                Quantity = 18
            }, new Store_Product
            {
                ID = 765,
                StoreID = 20,
                ProductID = 5,
                Quantity = 18
            }, new Store_Product
            {
                ID = 766,
                StoreID = 20,
                ProductID = 6,
                Quantity = 18
            }, new Store_Product
            {
                ID = 767,
                StoreID = 20,
                ProductID = 7,
                Quantity = 18
            }, new Store_Product
            {
                ID = 768,
                StoreID = 20,
                ProductID = 8,
                Quantity = 18
            }, new Store_Product
            {
                ID = 769,
                StoreID = 20,
                ProductID = 9,
                Quantity = 18
            }, new Store_Product
            {
                ID = 770,
                StoreID = 20,
                ProductID = 10,
                Quantity = 18
            }, new Store_Product
            {
                ID = 771,
                StoreID = 20,
                ProductID = 11,
                Quantity = 18
            }, new Store_Product
            {
                ID = 772,
                StoreID = 20,
                ProductID = 12,
                Quantity = 18
            }, new Store_Product
            {
                ID = 773,
                StoreID = 20,
                ProductID = 13,
                Quantity = 18
            }, new Store_Product
            {
                ID = 774,
                StoreID = 20,
                ProductID = 14,
                Quantity = 18
            }, new Store_Product
            {
                ID = 775,
                StoreID = 20,
                ProductID = 15,
                Quantity = 18
            }, new Store_Product
            {
                ID = 776,
                StoreID = 20,
                ProductID = 16,
                Quantity = 18
            }, new Store_Product
            {
                ID = 777,
                StoreID = 20,
                ProductID = 20,
                Quantity = 18
            }, new Store_Product
            {
                ID = 778,
                StoreID = 20,
                ProductID = 21,
                Quantity = 18
            }, new Store_Product
            {
                ID = 779,
                StoreID = 20,
                ProductID = 22,
                Quantity = 18
            }, new Store_Product
            {
                ID = 780,
                StoreID = 20,
                ProductID = 23,
                Quantity = 18
            }, new Store_Product
            {
                ID = 781,
                StoreID = 20,
                ProductID = 24,
                Quantity = 18
            }, new Store_Product
            {
                ID = 782,
                StoreID = 20,
                ProductID = 25,
                Quantity = 18
            }, new Store_Product
            {
                ID = 783,
                StoreID = 20,
                ProductID = 26,
                Quantity = 18
            }, new Store_Product
            {
                ID = 784,
                StoreID = 20,
                ProductID = 27,
                Quantity = 18
            }, new Store_Product
            {
                ID = 785,
                StoreID = 20,
                ProductID = 28,
                Quantity = 18
            }, new Store_Product
            {
                ID = 786,
                StoreID = 20,
                ProductID = 29,
                Quantity = 18
            }, new Store_Product
            {
                ID = 787,
                StoreID = 20,
                ProductID = 30,
                Quantity = 18
            }, new Store_Product
            {
                ID = 788,
                StoreID = 20,
                ProductID = 31,
                Quantity = 18
            }, new Store_Product
            {
                ID = 789,
                StoreID = 20,
                ProductID = 32,
                Quantity = 18
            }, new Store_Product
            {
                ID = 790,
                StoreID = 20,
                ProductID = 33,
                Quantity = 18
            }, new Store_Product
            {
                ID = 791,
                StoreID = 20,
                ProductID = 34,
                Quantity = 18
            }, new Store_Product
            {
                ID = 792,
                StoreID = 20,
                ProductID = 35,
                Quantity = 18
            }, new Store_Product
            {
                ID = 793,
                StoreID = 20,
                ProductID = 36,
                Quantity = 18
            }, new Store_Product
            {
                ID = 794,
                StoreID = 20,
                ProductID = 37,
                Quantity = 18
            }, new Store_Product
            {
                ID = 795,
                StoreID = 20,
                ProductID = 38,
                Quantity = 18
            }, new Store_Product
            {
                ID = 796,
                StoreID = 20,
                ProductID = 39,
                Quantity = 18
            }, new Store_Product
            {
                ID = 797,
                StoreID = 20,
                ProductID = 40,
                Quantity = 18
            }, new Store_Product
            {
                ID = 798,
                StoreID = 20,
                ProductID = 41,
                Quantity = 18
            }, new Store_Product
            {
                ID = 799,
                StoreID = 20,
                ProductID = 42,
                Quantity = 18
            }, new Store_Product
            {
                ID = 800,
                StoreID = 20,
                ProductID = 43,
                Quantity = 18
            });
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
