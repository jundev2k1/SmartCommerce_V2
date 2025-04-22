-- Copyright (c) 2025 - Jun Dev. All rights reserved

-- Create index for full-text search
CREATE INDEX IF NOT EXISTS idx_product_searchvector
    ON product USING GIN (search_vector);

CREATE INDEX IF NOT EXISTS idx_product_created_date
    ON product(created_at)
 WHERE del_flg = false;

CREATE INDEX IF NOT EXISTS idx_product_price
    ON product(price) 
 WHERE del_flg = false;
