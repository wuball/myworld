using System.Collections.Generic;
using Abp;
using Google.YouTube.Chat.Dto;
using Google.YouTube.Dto;

namespace Google.YouTube.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
