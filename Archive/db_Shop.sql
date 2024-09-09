CREATE DATABASE DB_Shop;

USE DB_Shop;

CREATE TABLE tb_Admin
(
	admin_id int PRIMARY KEY IDENTITY(1, 1),
	admin_name varchar(100),
	admin_email varchar(100) UNIQUE,
	a_password varchar(100),
	contact_no varchar(50),
	join_date DATETIME DEFAULT GETDATE(),
	updated_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE tb_User
(
	user_id int PRIMARY KEY IDENTITY(1, 1),
	user_name varchar(100),
	user_email varchar(100) UNIQUE,
	u_password varchar(100),
	contact_no varchar(50),
	gender varchar(20) CHECK (gender IN ('Male', 'Female')),
	join_date DATETIME DEFAULT GETDATE(),
	updated_at DATETIME DEFAULT GETDATE(),
	updated_by int FOREIGN KEY REFERENCES tb_Admin(admin_id)
);

CREATE TABLE tb_Categories
(
	category_id INT PRIMARY KEY IDENTITY(1,1),
	category_name VARCHAR(100),
	inserted_at DATETIME DEFAULT GETDATE(),
	updated_at DATETIME DEFAULT GETDATE(),
	updated_by INT FOREIGN KEY REFERENCES tb_Admin(admin_id) 
);

CREATE TABLE tb_Products
(
	product_id int PRIMARY KEY IDENTITY(1, 1),
	category_id int,
	product_name varchar(100),
	product_img varchar(max),
	price decimal(7, 2),
	stock int DEFAULT 0,
	model varchar(50),
	manufacturer varchar(50),
	description varchar(100),
	inserted_at DATETIME DEFAULT GETDATE(),
	updated_at DATETIME DEFAULT GETDATE(),
	FOREIGN KEY(category_id) REFERENCES tb_Categories(category_id),
	updated_by int FOREIGN KEY REFERENCES tb_Admin(admin_id)
);

CREATE TABLE tb_Orders
(
	order_id int PRIMARY KEY IDENTITY(1, 1),
	order_date datetime,
	shipping_cost decimal(6,2) DEFAULT 0,
	order_status varchar(50) DEFAULT 'waiting' CHECK (order_status IN ('waiting', 'confirmed', 'shipped', 'delivered', 'cancelled')),
	sub_total decimal(7,2),
	remarks varchar(100),
	user_id int FOREIGN KEY REFERENCES tb_User(user_id),
	updated_by int FOREIGN KEY REFERENCES tb_Admin(admin_id)
);

CREATE TABLE tb_Orders_Summary
(
	order_detail_id int PRIMARY KEY IDENTITY(1, 1),
	order_id int,
	product_id int,
	unit_price decimal(7,2) DEFAULT 0,
	quantity int,
	FOREIGN KEY(order_id) REFERENCES tb_Orders(order_id),
	FOREIGN KEY(product_id) REFERENCES tb_Products(product_id)
);

CREATE TABLE tb_Review
(
	review_id int PRIMARY KEY IDENTITY(1, 1),
	rating int CHECK (rating >= 0 and rating <= 5),
	review_text varchar(100),
	review_date DATETIME DEFAULT GETDATE(),
	product_id int,
	FOREIGN KEY(product_id) REFERENCES tb_Products(product_id),
	user_id int FOREIGN KEY REFERENCES tb_User(user_id)
);

CREATE TABLE tb_Comment
(
	comment_id int PRIMARY KEY IDENTITY(1, 1),
	review_id int,
	answer_text varchar(100),
	comment_date DATETIME DEFAULT GETDATE(),
	FOREIGN KEY(review_id) REFERENCES tb_Review(review_id),
	comment_by int FOREIGN KEY REFERENCES tb_Admin(admin_id)
);

CREATE TABLE tb_Wishlist
(
	wishlist_id int PRIMARY KEY IDENTITY(1, 1),
	product_id int,
	FOREIGN KEY(product_id) REFERENCES tb_Products(product_id),
	user_id int FOREIGN KEY REFERENCES tb_User(user_id)
);

select * from tb_Admin;