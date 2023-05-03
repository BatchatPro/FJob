using FJob.Repository.Models;
using FJob.Shared;

namespace FJob.Service.Mapper;

public static class ContactMapper
{
    public static ContactDTO ConvertToDTO(this Contact contact)
    {
        if (contact == null)
            return null;
        return new ContactDTO()
        {
            Id = contact.Id,
            Theme = contact.Theme,
            MoreInfo = contact.MoreInfo,
            PhoneNumber = contact.PhoneNumber
        };
    }

    public static Contact ConvertToEntity(this ContactDTO contact)
    {
        if (contact == null)
            return null;
        return new Contact()
        {
            Id = contact.Id,
            Theme = contact.Theme,
            MoreInfo = contact.MoreInfo,
            PhoneNumber = contact.PhoneNumber
        };
    }

    public static IEnumerable<ContactDTO> ConvertToDTO(this IEnumerable<Contact> contacts)
    {
        if (contacts == null)
            return null;
        return contacts.Select(contact => new ContactDTO()
        {
            Id = contact.Id,
            Theme = contact.Theme,
            MoreInfo = contact.MoreInfo,
            PhoneNumber = contact.PhoneNumber
        });
    }

    public static IEnumerable<Contact> ConvertToEntity(this IEnumerable<ContactDTO> contactDTOs)
    {
        if (contactDTOs == null)
            return null;
        return contactDTOs.Select(contact => new Contact()
        {
            Id = contact.Id,
            Theme = contact.Theme,
            MoreInfo = contact.MoreInfo,
            PhoneNumber = contact.PhoneNumber
        });
    }
}
