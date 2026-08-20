CREATE Table ticket (
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    created_by_id bigint NOT NULL REFERENCES account(id),
    assigned_to_id bigint REFERENCES account(id),
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    ticket_status text NOT NULL,
    title text NOT NULL,
    ticket_description text NOT NULL,
    lane_id bigint NOT NULL REFERENCES lane(id) ON DELETE CASCADE
    );