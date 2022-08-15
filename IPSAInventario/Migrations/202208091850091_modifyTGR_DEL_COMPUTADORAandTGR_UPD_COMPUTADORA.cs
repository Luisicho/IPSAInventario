﻿namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTGR_DEL_COMPUTADORAandTGR_UPD_COMPUTADORA : DbMigration
    {
        public override void Up()
        {
            /*ELIMINA LA COMPUTADORA EN TODAS LAS TABLAS RELACIONADAS, MENOS EN DETALLE DE FACTURA*/
            Sql("ALTER TRIGGER TGR_DEL_COMPUTADORA ON Computadora FOR DELETE AS BEGIN	SET NOCOUNT ON	DECLARE @IDC CHAR(7)	SET @IDC = (SELECT Codigo_PC FROM DELETED)	IF EXISTS(SELECT @IDC FROM Especificaciones)	 BEGIN		DELETE FROM Especificaciones WHERE Codigo_PC = @IDC		PRINT 'SE ELIMINO ESPECIFICACIONES DE COMPUTADORA'	 END	IF EXISTS(SELECT @IDC FROM Disponibilidad)	 BEGIN		DELETE FROM Disponibilidad WHERE Codigo_PC = @IDC		PRINT 'SE ELIMINO DISPONIBILIDAD DE COMPUTADORA'	 END	IF EXISTS(SELECT @IDC FROM Computadora_Software)	 BEGIN		DELETE FROM Computadora_Software WHERE Codigo_PC = @IDC		PRINT 'SE ELIMINO SOFTWARE DE COMPUTADORA'	 END	IF EXISTS(SELECT @IDC FROM Computadora_Perifericos)	 BEGIN		DELETE FROM Computadora_Perifericos WHERE Codigo_PC = @IDC		PRINT 'SE ELIMINO PERIFERICOS DE COMPUTADORA'	 END END");
            /*ACTUALIZA EL CODIGO_PC EN TODAS LAS TABLAS RELACIONADAS*/
            Sql("ALTER TRIGGER TGR_UPD_COMPUTADORA ON Computadora FOR UPDATE AS BEGIN	SET NOCOUNT ON	DECLARE @IDCD CHAR(7),@IDCI CHAR(7)	SET @IDCD = (SELECT Codigo_PC FROM DELETED)	SET @IDCI = (SELECT Codigo_PC FROM INSERTED)	IF EXISTS(SELECT @IDCD FROM Especificaciones)	 BEGIN		UPDATE Especificaciones SET Codigo_PC = @IDCI WHERE Codigo_PC = @IDCD		PRINT 'SE ACTUALIZO CODIGO_PC ESPECIFICACIONES DE COMPUTADORA'	 END	IF EXISTS(SELECT @IDCD FROM Disponibilidad)	 BEGIN		UPDATE Disponibilidad SET Codigo_PC = @IDCI WHERE Codigo_PC = @IDCD		PRINT 'SE ACTUALIZO CODIGO_PC DISPONIBILIDAD DE COMPUTADORA'	 END	IF EXISTS(SELECT @IDCD FROM Computadora_Software)	 BEGIN	UPDATE Computadora_Software SET Codigo_PC = @IDCI WHERE Codigo_PC = @IDCD		PRINT 'SE ACTUALIZO CODIGO_PC SOFTWARE DE COMPUTADORA'	 END	IF EXISTS(SELECT @IDCD FROM Computadora_Perifericos)	 BEGIN		UPDATE Computadora_Perifericos SET Codigo_PC = @IDCI WHERE Codigo_PC = @IDCD		PRINT 'SE ACTUALIZO CODIGO_PC PERIFERICOS DE COMPUTADORA'	 END	IF EXISTS(SELECT @IDCD FROM Factura_Detalle_Comp)	 BEGIN		UPDATE Factura_Detalle_Comp SET Codigo_PC = @IDCI WHERE Codigo_PC = @IDCD		PRINT 'SE ACTUALIZO CODIGO_PC DETALLE DE COMPUTADORA'	 END END");
        }

        public override void Down()
        {
        }
    }
}
