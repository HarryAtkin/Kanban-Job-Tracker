CREATE Table board (
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY, 
    owner_id bigint NOT NULL REFERENCES account(id) ON DELETE CASCADE,
    title TEXT NOT NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
    );