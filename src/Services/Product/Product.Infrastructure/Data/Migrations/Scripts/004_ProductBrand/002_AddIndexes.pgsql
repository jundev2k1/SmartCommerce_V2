-- Copyright (c) 2025 - Jun Dev. All rights reserved

CREATE UNIQUE INDEX IF NOT EXISTS ux_product_brand_no
    ON product_brand(product_id, brand_no);