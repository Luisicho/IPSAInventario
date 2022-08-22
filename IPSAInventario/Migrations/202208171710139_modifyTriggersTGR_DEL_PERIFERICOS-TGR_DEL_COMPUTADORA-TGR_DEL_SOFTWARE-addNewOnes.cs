﻿namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTriggersTGR_DEL_PERIFERICOSTGR_DEL_COMPUTADORATGR_DEL_SOFTWAREaddNewOnes : DbMigration
    {
        public override void Up()
        {
            //ELIMINA EL PERIFERICO EN TODAS LAS TABLAS RELACIONADAS
            Sql("ALTER TRIGGER TGR_DEL_PERIFERICOS ON Perifericos FOR DELETE AS BEGIN	SET NOCOUNT ON	DECLARE @IDP CHAR(7)	SET @IDP = (SELECT IDPeriferico FROM DELETED)	IF EXISTS(SELECT @IDP FROM Impresora)	 BEGIN		DELETE FROM Impresora WHERE IDPeriferico = @IDP		PRINT 'SE ELIMINO IMPRESORA'	 END	IF EXISTS(SELECT @IDP FROM Auxiliar)	 BEGIN		DELETE FROM Auxiliar WHERE IDPeriferico = @IDP		PRINT 'SE ELIMINO AUXILIAR'	 END	IF EXISTS(SELECT @IDP FROM Monitor)	 BEGIN		DELETE FROM Monitor WHERE IDPeriferico = @IDP		PRINT 'SE ELIMINO MONITOR'	 END	IF EXISTS(SELECT @IDP FROM Computadora_Perifericos)	 BEGIN		DELETE FROM Computadora_Perifericos WHERE IDPeriferico = @IDP		PRINT 'SE ELIMINO PERIFERICO DE COMPUTADORA'	 END	IF EXISTS(SELECT @IDP FROM Ranura_Detalle_Per)	 BEGIN		DELETE FROM Ranura_Detalle_Per WHERE IDPeriferico = @IDP		PRINT 'SE ELIMINO PERIFERICO DE RANURA'	 END IF EXISTS(SELECT @IDP FROM Factura_Detalle_Per) BEGIN DELETE FROM Factura_Detalle_Per WHERE IDPeriferico = @IDP PRINT 'SE ELIMINO DETALLER DE PERIFERICO' END END");
            //ELIMINA LA COMPUTADORA EN TODAS LAS TABLAS RELACIONADAS
            Sql("ALTER TRIGGER TGR_DEL_COMPUTADORA ON Computadora FOR DELETE AS BEGIN	SET NOCOUNT ON	DECLARE @IDC CHAR(7)	SET @IDC = (SELECT Codigo_PC FROM DELETED)	IF EXISTS(SELECT @IDC FROM Especificaciones)	 BEGIN		DELETE FROM Especificaciones WHERE Codigo_PC = @IDC		PRINT 'SE ELIMINO ESPECIFICACIONES DE COMPUTADORA'	 END	IF EXISTS(SELECT @IDC FROM Disponibilidad)	 BEGIN		DELETE FROM Disponibilidad WHERE Codigo_PC = @IDC		PRINT 'SE ELIMINO DISPONIBILIDAD DE COMPUTADORA'	 END	IF EXISTS(SELECT @IDC FROM Computadora_Software)	 BEGIN		DELETE FROM Computadora_Software WHERE Codigo_PC = @IDC		PRINT 'SE ELIMINO SOFTWARE DE COMPUTADORA'	 END	IF EXISTS(SELECT @IDC FROM Computadora_Perifericos)	 BEGIN		DELETE FROM Computadora_Perifericos WHERE Codigo_PC = @IDC		PRINT 'SE ELIMINO PERIFERICOS DE COMPUTADORA'	 END IF EXISTS(SELECT @IDC FROM Factura_Detalle_Comp) BEGIN DELETE FROM Factura_Detalle_Comp WHERE Codigo_PC = @IDC PRINT 'SE ELIMINO DETALLE DE COMPUTADORA' END IF EXISTS(SELECT @IDC FROM Ranuras)	 BEGIN DELETE FROM Ranuras WHERE Codigo_PC = @IDC PRINT 'SE ELIMINO RANURAS DE COMPUTADORA' END IF EXISTS(SELECT @IDC FROM Bitacora) BEGIN	DELETE FROM Bitacora WHERE Codigo_PC = @IDC	PRINT 'SE ELIMINO BITACORAS DE COMPUTADORA' END END");
            //ELIMINA EL SOFTWARE EN TODAS LAS TABLAS RELACIONADAS
            Sql("ALTER TRIGGER TGR_DEL_SOFTWARE	ON Software	FOR DELETE	AS	BEGIN	SET NOCOUNT ON	DECLARE @IDS INT SET @IDS = (SELECT IDSoftware FROM DELETED) IF EXISTS(SELECT @IDS FROM Computadora_Software) BEGIN DELETE FROM Computadora_Software WHERE IDSoftware = @IDS PRINT 'SE ELIMINO SOFTWARE DE COMPUTADORA'	END IF EXISTS(SELECT @IDS FROM Factura_Detalle_Soft) BEGIN	DELETE FROM Factura_Detalle_Soft WHERE IDSoftware = @IDS PRINT 'SE ELIMINO DETALLE DE SOFTWARE' END END");
            //ELIMINA HARDWARE EN TODAS LAS TABLAS RELACIONADAS
            Sql("CREATE TRIGGER TGR_DEL_HARDWARE ON Hardware FOR DELETE AS BEGIN	SET NOCOUNT ON	DECLARE @IDH INT SET @IDH = (SELECT IDHardware FROM DELETED)	IF EXISTS(SELECT @IDH FROM Ranura_Detalle_Hard)	 BEGIN		DELETE FROM Ranura_Detalle_Hard WHERE IDHardware = @IDH		PRINT 'SE ELIMINO HARWARE DE RANURA'	 END END");
        }

        public override void Down()
        {
        }
    }
}
