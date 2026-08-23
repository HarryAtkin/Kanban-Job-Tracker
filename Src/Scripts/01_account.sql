CREATE Table account (
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY, 
    f_name TEXT NOT NULL,
    l_name TEXT NOT NULL,
    email TEXT NOT NULL UNIQUE,
    user_password TEXT NOT NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
    );