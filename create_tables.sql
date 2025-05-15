-- Create users table
CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    role ENUM('admin', 'client') NOT NULL DEFAULT 'client',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create services table
CREATE TABLE IF NOT EXISTS services (
    service_id INT AUTO_INCREMENT PRIMARY KEY,
    service_name VARCHAR(100) NOT NULL,
    description TEXT,
    price DECIMAL(10,2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create orders table
CREATE TABLE IF NOT EXISTS orders (
    order_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    service_id INT NOT NULL,
    order_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    status ENUM('pending', 'processing', 'completed', 'cancelled') DEFAULT 'pending',
    total_amount DECIMAL(10,2) NOT NULL,
    pickup_date DATETIME NOT NULL,
    delivery_date DATETIME NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (service_id) REFERENCES services(service_id)
);

-- Insert default admin user
INSERT INTO users (username, password, email, role) 
VALUES ('admin', 'admin123', 'admin@laundry.com', 'admin')
ON DUPLICATE KEY UPDATE username = username;

-- Insert some sample services
INSERT INTO services (service_name, description, price) VALUES
('Wash & Fold', 'Regular laundry service with washing and folding', 5.00),
('Dry Cleaning', 'Professional dry cleaning service', 10.00),
('Ironing', 'Professional ironing service', 3.00),
('Express Service', 'Same day laundry service', 15.00)
ON DUPLICATE KEY UPDATE service_name = service_name; 