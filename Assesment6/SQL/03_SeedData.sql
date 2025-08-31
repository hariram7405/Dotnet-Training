USE ShopTrackPro;
GO

-- Insert Users
INSERT INTO Users (Username, Email, PasswordHash, Role) VALUES
('admin', 'admin@shoptrack.com', 'AQAAAAEAACcQAAAAEHashed', 'Admin'),
('seller1', 'seller@shoptrack.com', 'AQAAAAEAACcQAAAAEHashed', 'Seller'),
('john_doe', 'john@example.com', 'AQAAAAEAACcQAAAAEHashed', 'Customer'),
('jane_smith', 'jane@example.com', 'AQAAAAEAACcQAAAAEHashed', 'Customer');

-- Insert Products
INSERT INTO Products (Name, Description, Price, Category) VALUES
('Laptop', 'High-performance laptop', 999.99, 'Electronics'),
('Mouse', 'Wireless optical mouse', 29.99, 'Electronics'),
('Keyboard', 'Mechanical gaming keyboard', 79.99, 'Electronics'),
('Monitor', '24-inch LED monitor', 199.99, 'Electronics'),
('Headphones', 'Noise-cancelling headphones', 149.99, 'Electronics');

-- Insert Orders
INSERT INTO Orders (UserId, OrderDate, Status) VALUES
(2, GETUTCDATE(), 'Completed'),
(3, GETUTCDATE(), 'Pending');

-- Insert OrderItems
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES
(1, 1, 1),
(1, 2, 2),
(2, 3, 1);

GO