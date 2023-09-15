using System.Collections.Generic;
using Google.YouTube.Auditing.Dto;
using Google.YouTube.Dto;

namespace Google.YouTube.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
