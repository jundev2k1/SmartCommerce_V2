-- Copyright (c) 2025 - Jun Dev. All rights reserved

CREATE INDEX IF NOT EXISTS idx_product_related_product
    ON product_related(product_id);

CREATE INDEX IF NOT EXISTS idx_product_related_variant
    ON product_related(related_product_id);

CREATE INDEX IF NOT EXISTS idx_product_related_variant
    ON product_related(related_variant_id);
