-- Copyright (c) 2025 - Jun Dev. All rights reserved

CREATE INDEX IF NOT EXISTS idx_product_category_product_id
    ON product_category(product_id);

CREATE INDEX IF NOT EXISTS idx_product_category_category_id
    ON product_category(category_id);
