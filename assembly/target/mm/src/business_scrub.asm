business_scrub_before_give_item_clock_town_hook:
    addiu   sp, sp, -0x20
    sw      ra, 0x0018 (sp)
    sw      a0, 0x0010 (sp)

    jal     business_scrub_before_give_item_clock_town
    sw      a1, 0x0014 (sp)

    lw      a0, 0x0010 (sp)
    lw      a1, 0x0014 (sp)
    lw      ra, 0x0018 (sp)
    jr      ra
    addiu   sp, sp, 0x20
