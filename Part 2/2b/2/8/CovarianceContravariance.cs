// ===== Ковариантность =====
class DocumentRequest { }
class PdfRequest : DocumentRequest { }

interface IDocumentReader<out T>
{
    T Read();
}

// Сохранятеся родительская логика, параметризуемая потомком
class PdfReader : IDocumentReader<PdfRequest>
{
    public PdfRequest Read() => new PdfRequest();
}

// ===== Контравариантность =====
interface IRequestLogger<in T>
{
    void Log(T request);
}

// Подразумевая логирование универсальных документов, можно логировать в т.ч. pdf-документы
class RequestLogger : IRequestLogger<DocumentRequest>
{
    public void Log(DocumentRequest _) {...};
}
