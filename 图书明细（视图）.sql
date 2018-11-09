SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

ALTER  VIEW dbo.图书明细
AS
SELECT dbo.BookList.BarCode, dbo.BookLocation.BookLocationId, 
      dbo.BookLocation.BookLocationInfo, dbo.BookLocation.BookRoomInfo, 
      dbo.BookList.BookId, dbo.book.ID, dbo.book.书名, dbo.book.并列提名, 
      dbo.book.副提名, dbo.book.出版地, dbo.book.出版者, dbo.book.出版日期, 
      dbo.book.页数, dbo.book.开本, dbo.book.附件, dbo.book.价格, dbo.book.附注, 
      dbo.book.文种号, dbo.book.图书分类号, dbo.book.种次号, dbo.book.年代顺序号, 
      dbo.book.入库日期, dbo.book.馆藏量, dbo.book.借出次数, dbo.book.借出书量, 
      dbo.book.拒借次数, dbo.book.拒借标记, dbo.book.有效规范, dbo.book.失效规范, 
      dbo.book.指针, dbo.book.内容提要
FROM dbo.book RIGHT OUTER JOIN
      dbo.BookList ON dbo.book.ID = dbo.BookList.BookId LEFT OUTER JOIN
      dbo.BookLocation ON dbo.BookList.BookLocation = dbo.BookLocation.BookLocationId

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

