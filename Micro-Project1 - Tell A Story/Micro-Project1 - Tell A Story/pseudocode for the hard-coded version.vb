DEFINE CLASS CharacterInfo
    PRIVATE INTEGER _age

    PROPERTY INTEGER Age
        GET -> RETURN _age
        SET(value)
            IF value < 0 THEN
                PRINT "Age cannot be negative. Setting Age to 0."
                _age <- 0
            ELSE
                _age <- value
            ENDIF
    END PROPERTY

    PROPERTY STRING Name
    PROPERTY STRING Job
    PROPERTY INTEGER HeightInInches
    PROPERTY STRING[] FavoriteActivities
END CLASS


MAIN
    PRINT "=== Character Builder (Hard-Coded Jake) ==="

    // Create the object
    c <- NEW CharacterInfo()

    // Hard-code required fields
    c.Name <- "Jake FromStateFarm"
    c.Age  <- 31
    c.Job  <- "Insurance Agent"
    c.FavoriteActivities <- ["selling insurance", "wearing red"]

    // Menu loop (ends only when we return/exit)
    WHILE TRUE
        PRINT BLANK_LINE
        PRINT "Menu:"
        PRINT "1) Enter height (inches)"
        PRINT "2) Add more favorite activities"
        PRINT "3) Show current values"
        PRINT "4) Tell the story now"
        PRINT "5) Exit"
        PRINT "Choose 1-5: "
        choice <- READLINE

        SWITCH choice
            CASE "1":
                c.HeightInInches <- READ_INT("Enter height in inches (whole number): ", min=0)
                BREAK SWITCH

            CASE "2":
                // Use a dynamic list so we don't manually resize arrays
                list <- TO_LIST(c.FavoriteActivities)
                PRINT "Enter activities (blank line to finish):"
                LOOP
                    PRINT "  Activity: "
                    activity <- READLINE
                    IF activity IS NULL OR TRIM(activity) = "" THEN
                        BREAK LOOP
                    ENDIF
                    ADD activity TO list
                END LOOP
                c.FavoriteActivities <- TO_ARRAY(list)
                PRINT "Activities updated."
                BREAK SWITCH

            CASE "3":
                SHOW_SUMMARY(c)
                BREAK SWITCH

            CASE "4":
                PRINT BLANK_LINE
                PRINT "Telling your complete story now..."
                SHOW_SUMMARY(c)     // show EVERYTHING first (incl. hard-coded)
                TELL_STORY(c)
                RETURN              // exit program

            CASE "5":
                PRINT "Goodbye!"
                RETURN              // exit program

            DEFAULT:
                PRINT "Please choose a valid option (1–5)."
        END SWITCH

        // ---- AUTO-TELL WHEN *ALL* INPUTS ARE PRESENT ----
        // Requires: Name, Age, Job, >=1 activity, and Height > 0
        IF ALL_INPUTS_PRESENT(c) THEN
            PRINT BLANK_LINE
            PRINT "All inputs collected. Here is a summary of EVERYTHING:"
            SHOW_SUMMARY(c)
            PRINT BLANK_LINE
            PRINT "Now telling your complete story..."
            TELL_STORY(c)
            RETURN
        ENDIF
    END WHILE
END MAIN


FUNCTION SHOW_SUMMARY(c: CharacterInfo)
    PRINT "--- Current Character ---"
    PRINT "Name:   " + c.Name
    PRINT "Age:    " + c.Age
    PRINT "Job:    " + c.Job
    PRINT "Height: " + c.HeightInInches + " inches"
    IF LENGTH(c.FavoriteActivities) = 0 THEN
        PRINT "Favorites: (none)"
    ELSE
        PRINT "Favorites: " + JOIN(c.FavoriteActivities, ", ")
    ENDIF
END FUNCTION


FUNCTION TELL_STORY(c: CharacterInfo)
    PRINT "=== Your Character Story ==="
    PRINT "This is " + c.Name + ". " +
          c.Name + " is " + c.Age + " years old, " +
          c.HeightInInches + " inches tall, and works as an " +
          TO_LOWER(c.Job) + "."
    IF LENGTH(c.FavoriteActivities) = 0 THEN
        PRINT c.Name + " hasn't listed any favorite activities yet."
    ELSE
        PRINT c.Name + " enjoys:"
        FOR EACH activity IN c.FavoriteActivities
            PRINT " - " + activity
        END FOR
    ENDIF
END FUNCTION


FUNCTION READ_INT(prompt, min = -∞, max = +∞) RETURNS INTEGER
    LOOP
        PRINT prompt
        text <- READLINE
        IF text CAN PARSE TO INTEGER AS value THEN
            IF value < min THEN
                PRINT "Please enter a number >= " + min
            ELSE IF value > max THEN
                PRINT "Please enter a number <= " + max
            ELSE
                RETURN value
            ENDIF
        ELSE
            PRINT "Please enter a whole number (e.g., 68)."
        ENDIF
    END LOOP
END FUNCTION


FUNCTION ALL_INPUTS_PRESENT(c: CharacterInfo) RETURNS BOOLEAN
    RETURN
        TRIM(c.Name) != "" AND
        c.Age >= 0 AND
        TRIM(c.Job) != "" AND
        c.HeightInInches > 0 AND
        c.FavoriteActivities != NULL AND
        LENGTH(c.FavoriteActivities) > 0
END FUNCTION
