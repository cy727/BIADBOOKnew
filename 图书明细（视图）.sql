SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

ALTER  VIEW dbo.ͼ����ϸ
AS
SELECT dbo.BookList.BarCode, dbo.BookLocation.BookLocationId, 
      dbo.BookLocation.BookLocationInfo, dbo.BookLocation.BookRoomInfo, 
      dbo.BookList.BookId, dbo.book.ID, dbo.book.����, dbo.book.��������, 
      dbo.book.������, dbo.book.�����, dbo.book.������, dbo.book.��������, 
      dbo.book.ҳ��, dbo.book.����, dbo.book.����, dbo.book.�۸�, dbo.book.��ע, 
      dbo.book.���ֺ�, dbo.book.ͼ������, dbo.book.�ִκ�, dbo.book.���˳���, 
      dbo.book.�������, dbo.book.�ݲ���, dbo.book.�������, dbo.book.�������, 
      dbo.book.�ܽ����, dbo.book.�ܽ���, dbo.book.��Ч�淶, dbo.book.ʧЧ�淶, 
      dbo.book.ָ��, dbo.book.������Ҫ
FROM dbo.book RIGHT OUTER JOIN
      dbo.BookList ON dbo.book.ID = dbo.BookList.BookId LEFT OUTER JOIN
      dbo.BookLocation ON dbo.BookList.BookLocation = dbo.BookLocation.BookLocationId

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

