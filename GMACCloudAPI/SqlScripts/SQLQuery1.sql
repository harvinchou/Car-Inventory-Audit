select * from AssetRegistrations 
where OperatorLoginAccount = '0001'

select * from AssetCheckJobs
where OperatorLoginAccount = '0001'

select * from AssetCheckItems
where TaskCode = 'TP-20151231-001'

-------------------------------------------------------------------------------------------------
select * from AssetRegistrations where OperatorLoginAccount = '0001'

declare @count int
declare @countstr char(4)
set @count = 1
while (@count <= 1000)
begin
  set @countstr = right('000' + ltrim(str(@count, 4)), 4)

  insert into AssetRegistrations (VIN, RFIDCode, Dealer, OperatorLoginAccount, CreatedOn)
  values ('1G2NW12E25M20'+@countstr, '223456789'+@countstr, '3333', '0003', convert(varchar, getdate(), 126))

  set @count = @count + 1
end

delete from AssetRegistrations where OperatorLoginAccount = '0003'

-------------------------------------------------------------------------------------------------
insert into AssetCheckJobs (TaskCode, Dealer, OperatorLoginAccount, CreatedOn)
values ('TP-20151231-001','1111','0001', convert(varchar, getdate(), 126))

insert into AssetCheckItems (TaskCode, VIN, RFIDCode)
select 'TP-20151231-001' as TaskCode, ar.VIN, ar.RFIDCode
from AssetRegistrations ar
where ar.OperatorLoginAccount = '0001'

delete from AssetCheckItems where TaskCode = 'TP-20151231-001'
delete from AssetCheckJobs where TaskCode = 'TP-20151231-001'

-------------------------------------------------------------------------------------------------
delete from AssetRegistrations
delete from AssetCheckItems
delete from AssetCheckJobs

insert into AssetCheckItems (TaskCode, VIN, RFIDCode)
select 'TP-20151231-001' as TaskCode, ar.VIN, ar.RFIDCode
from AssetRegistrations ar
where ar.OperatorLoginAccount = '0001'