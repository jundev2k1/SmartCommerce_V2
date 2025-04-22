-- Copyright (c) 2025 - Jun Dev. All rights reserved

CREATE UNIQUE INDEX IF NOT EXISTS idx_product_variants_sku
    ON product_variant(sku);

CREATE INDEX IF NOT EXISTS idx_product_variants_product_id
    ON product_variant(product_id);

CREATE INDEX IF NOT EXISTS idx_product_variants_priority
    ON product_variant(priority);

CREATE INDEX IF NOT EXISTS idx_product_variants_search_vector
    ON product_variant USING GIN(search_vector);

CREATE INDEX IF NOT EXISTS idx_product_variants_color
    ON product_variant(color);

CREATE INDEX IF NOT EXISTS idx_product_variants_display_period
    ON product_variant(display_start, display_end);

CREATE INDEX IF NOT EXISTS idx_product_variants_is_default
    ON product_variant(product_id, is_default);