using NopClone.Data.Context;
using NopClone.Data.Entities;

namespace NopClone.WebApi.ServiceExtension;

public static class SeedDataExtensions
{
    public static void SeedData(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var ctx = scope.ServiceProvider.GetRequiredService<NopCloneDataContext>();

            if (!ctx.Products.Any())
            {
                #region Seed Manufacturers
                ctx.AddRange(new List<Manufacturer>
                {
                    new Manufacturer
                    {
                        Id = "apple",
                        Name = "Apple"
                    },
                    new Manufacturer
                    {
                        Id = "sortcompany",
                        Name = "Sortcompany"
                    },
                    new Manufacturer
                    {
                        Id = "lenovo",
                        Name = "Lenovo "
                    },
                    new Manufacturer
                    {
                        Id = "shinigami-couture",
                        Name = "Shinigami Couture"
                    },
                    new Manufacturer
                    {
                        Id = "sangvinik-kyiv",
                        Name = "SANGVINIK"
                    },
                    new Manufacturer
                    {
                        Id = "undersoulwear",
                        Name = "UNDERSOUL"
                    },
                });
                #endregion Seed Manufacturers

                #region Seed Products
                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Apple MacBook Pro 13-inch",
                        Description = "test description",
                        Price = 1800,
                        ShowOnHomePage = true,
                        CreatedAt = DateTime.Now,
                        Deleted = false,
                        ManufacturerID = "apple",
                        Images = new[]
                        {
                            new Image
                            {
                                Id = "apple-macbook-pro-13-inch", FileName = "apple-macbook-pro-13-inch_415.jpeg",
                                Type = ImageTypes.Product
                            },
                        },
                        Attributes = new[]
                        {
                            new SpecificationAttribute { Name = "Screensize", Value = "13.0\"" },
                            new SpecificationAttribute { Name = "CPU Type", Value = "Intel Core i5" },
                            new SpecificationAttribute { Name = "Memory", Value = "4 GB" },
                        }
                    },
                    new Product
                    {
                        ManufacturerID = "lenovo",
                        Name = "Lenovo Thinkpad X1 Carbon Laptop",
                        Description = "Lenovo Thinkpad X1 Carbon Touch Intel Core i7 14 Ultrabook",
                        Price = 1360,
                        ShowOnHomePage = true,
                        Deleted = false,
                        Images = new[]
                        {
                            new Image
                            {
                                Id = "lenovo-thinkpad-x1-carbon",
                                FileName = "lenovo-thinkpad-x1-carbon-laptop_550.jpeg",
                                Type = ImageTypes.Product
                            },
                        }
                    },
                    new Product
                    {
                        ManufacturerID = "shinigami-couture",
                        Name = "F13 FULL ZIP HOODIE",
                        Description = "100% heavy cotton 420gsm YKK zipper Premium rhinestones",
                        Price = 90,
                        ShowOnHomePage = true,
                        Deleted = false,
                        Images = new[]
                        {
                            new Image
                            {
                                Id = "shinigami-zip", FileName = "shinigami-zip-hoodie.png", Type = ImageTypes.Product
                            },
                        }
                    },
                    new Product
                    {
                        ManufacturerID = "apple",
                        Name = "Apple iPhone 13 Pro",
                        Description = "Fake description",
                        Price = 1200,
                        ShowOnHomePage = true,
                        Deleted = false,
                        Images = new[]
                        {
                            new Image
                            {
                                Id = $"iphone-13__{Guid.NewGuid().ToString()}", FileName = "iphone-13-pro.jpg",
                                Type = ImageTypes.Product
                            },
                        }
                    },
                };
                
                ctx.AddRange(products);

                #endregion Products Seed

                #region Seed Categories
                var categories = new List<Category>
                {
                    new Category
                    {
                        Id = "computers",
                        Name = "Computers",
                        ViewPath = "Computers",
                        IncludeInTopMenu = true,
                        Depth = 1,
                        SubCategories = new[]
                        {
                            new Category
                            {
                                Id = "desktops",
                                Name = "Desktops", Depth = 2, ViewPath = "Computers>>Desktops",
                                Image = new Image
                                {
                                    Id = "desktops-img", Type = ImageTypes.Category,
                                    FileName = "0000002_desktops_450.jpg"
                                }
                            },
                            new Category
                            {
                                Id = "notebooks",

                                Name = "Notebooks", Depth = 2, ViewPath = "Computers>>Notebooks",
                                Image = new Image
                                    { Id = "notebooks-img", FileName = "notebooks_450.jpg", Type = ImageTypes.Category }
                            },
                            new Category
                            {
                                Id = "software",

                                Name = "Software", Depth = 2, ViewPath = "Computers>>Software",
                                Image = new Image
                                {
                                    Id = "software-img", FileName = "0000004_software_450.jpg",
                                    Type = ImageTypes.Category
                                }
                            },
                        }
                    },
                    new Category
                    {
                        Id = "electronics",
                        Name = "Electronics",
                        IncludeInTopMenu = true,
                        ShowOnHomePage = true,

                        SubCategories = new[]
                        {
                            new Category { Id = "cameras-and-photoes", Name = "Camera & photo" },
                            new Category { Id = "cell-phones", Name = "Cell phones" },
                            new Category { Id = "others", Name = "Others" },
                        },
                        Image = new Image
                        {
                            Id = "electronics-category-img", FileName = "electronics_category.jpeg",
                            Type = ImageTypes.Category
                        }
                    },
                    new Category
                    {
                        Id = "apparel",
                        Name = "Apparel",
                        IncludeInTopMenu = true,
                        ShowOnHomePage = false,

                        SubCategories = new[]
                        {
                            new Category { Id = "shoes", Name = "Shoes" },
                            new Category
                            {
                                Id = "clothing",
                                Name = "Clothing",
                                Image = new Image
                                {
                                    Id = $"clothing-sub-img__{Guid.NewGuid()}", FileName = "clothing_450.jpeg",
                                    Type = ImageTypes.Category
                                }
                            },
                            new Category { Id = "accessories", Name = "Accessories" },
                        },
                        Image = new Image
                            { Id = "apparel-category-img", FileName = "apparel.jpeg", Type = ImageTypes.Category }
                    },
                    new Category
                    {
                        Id = "digital-downloads",
                        Name = "Digital downloads",
                        IncludeInTopMenu = true,
                        ShowOnHomePage = true,

                        Image = new Image
                        {
                            Id = "digital-downloads", FileName = "digital-downloads.jpeg", Type = ImageTypes.Category
                        }
                    },
                    new Category
                    {
                        Id = "books",
                        Name = "Books",
                        IncludeInTopMenu = true,
                    },
                    new Category
                    {
                        Id = "gift-cards",
                        Name = "Gift Cards",
                        IncludeInTopMenu = true,
                    },
                };

                ctx.AddRange(categories);

                #endregion

                ctx.SaveChanges();

                // category products relationship
                ctx.Add(new ProductCategory
                {
                    CategoryId = "computers",
                    ProductId = products[0].Id,
                });
                ctx.Add(new ProductCategory
                {
                    CategoryId = "notebooks",
                    ProductId = products[0].Id,
                });

                ctx.Add(new ProductCategory
                {
                    CategoryId = "computers",
                    ProductId = products[1].Id,
                });
                ctx.Add(new ProductCategory
                {
                    CategoryId = "notebooks",
                    ProductId = products[1].Id,
                });

                ctx.Add(new ProductCategory
                {
                    CategoryId = "apparel",
                    ProductId = products[2].Id,
                });
                ctx.Add(new ProductCategory
                {
                    CategoryId = "clothing",
                    ProductId = products[2].Id,
                });

                ctx.Add(new ProductCategory
                {
                    CategoryId = "electronics",
                    ProductId = products[3].Id,
                });
                ctx.Add(new ProductCategory
                {
                    CategoryId = "cell-phones",
                    ProductId = products[3].Id,
                });

                ctx.SaveChanges();
            }
        }
    }
}