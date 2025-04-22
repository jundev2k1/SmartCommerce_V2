-- Copyright (c) 2025 - Jun Dev. All rights reserved

CREATE INDEX IF NOT EXISTS idx_product_images_product_id
    ON product_images (product_id);

CREATE INDEX IF NOT EXISTS idx_product_images_type
    ON product_images (type);

