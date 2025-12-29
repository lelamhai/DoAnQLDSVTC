CREATE VIEW V_GET_SUBSCRIBES AS
SELECT PUBS.description AS TENKHOA, SUBS.subscriber_server AS TENSERVER
FROM sysmergepublications AS PUBS INNER JOIN sysmergesubscriptions AS SUBS 
ON PUBS.pubid = SUBS.pubid AND PUBS.publisher <> SUBS.subscriber_server