# Shell script for replacing all instances of a word in a directory
find . -type f -exec sed -i 's/WarehouseApp2.Models/WarehouseService.Models/g' {} +
