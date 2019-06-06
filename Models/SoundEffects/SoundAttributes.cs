﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MMRando.Models.SoundEffects
{
    public static class SoundAttributes
    {
        /// <summary>
        /// Marks a sound effect as replacable, requiring a base instruction and at least one address
        /// </summary>
        [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
        public sealed class ReplacableAttribute : Attribute
        {
            public ReadOnlyCollection<int> Addresses { get; private set; }
            public uint Instruction { get; private set; }

            public ReplacableAttribute(uint instruction, int address, params int[] additionalAddresses)
            {
                Instruction = instruction & 0xFFFF0F00;

                var addresses = new List<int> { address };
                if (additionalAddresses?.Length > 0)
                {
                    addresses.AddRange(additionalAddresses);
                }

                Addresses = new ReadOnlyCollection<int>(addresses);
            }
        }

        /// <summary>
        /// Specify which tags are valid for replacing the sound.
        /// </summary>
        public sealed class ReplacableByTagsAttribute : Attribute
        {
            public ReadOnlyCollection<SoundEffectTag> Tags { get; private set; }

            public ReplacableByTagsAttribute(SoundEffectTag tag, params SoundEffectTag[] additionalTags)
            {
                var tags = new List<SoundEffectTag> { tag };
                if (additionalTags?.Length > 0)
                {
                    tags.AddRange(additionalTags);
                }

                Tags = new ReadOnlyCollection<SoundEffectTag>(tags);
            }
        }

        /// <summary>
        /// Mark the sound effect with tags. E.g. Short.
        /// </summary>
        [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
        public sealed class TagsAttribute : Attribute
        {
            public ReadOnlyCollection<SoundEffectTag> Tags { get; private set; }

            public TagsAttribute(SoundEffectTag tag, params SoundEffectTag[] additionalTags)
            {
                var tags = new List<SoundEffectTag> { tag };
                if (additionalTags?.Length > 0)
                {
                    tags.AddRange(additionalTags);
                }

                Tags = new ReadOnlyCollection<SoundEffectTag>(tags);
            }
        }
    }
}