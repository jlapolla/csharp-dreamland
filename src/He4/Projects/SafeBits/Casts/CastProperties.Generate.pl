#!/usr/bin/perl

use strict;
use warnings;

my $defaultInputRecordSeparator = $/;
my $defaultOutputRecordSeparator = $\;

my $integralTypes = ["SByte", "Byte", "Int16", "UInt16", "Int32", "UInt32", "Int64", "UInt64"];

# *.cs files use CRLF line endings
$/ = "\r\n";
$\ = "\r\n";

# Read template into memory

open(my $templateFileHandle, "<:encoding(UTF-8)", "CastProperties.Template.cs") or die $!;

my $templateFileLines = [];
@$templateFileLines = <$templateFileHandle>;
chomp(@$templateFileLines);

close($templateFileHandle) or die $!;

# Read head of main file into memory

open(my $headFileHandle, "<:encoding(UTF-8)", "CastProperties.cs") or die $!;

my $headFileLines = [];
my $curlyCount = 0;

while (my $line = <$headFileHandle>)
{

  chomp($line);
  push(@$headFileLines, $line);

  if ($line =~ /^\s*\{\s*$/)
  {

    $curlyCount += 1;

    if ($curlyCount == 2)
    {

      last;
    }
  }
}

close($headFileHandle) or die $!;

# Overwrite main file

open(my $mainFileHandle, ">:encoding(UTF-8)", "CastProperties.cs") or die $!;

for my $line (@$headFileLines)
{

  print $mainFileHandle $line;
}

$headFileLines = undef; # Allow garbage collection

for my $type1 (@$integralTypes)
{

  for my $type2 (@$integralTypes)
  {

    for my $line (@$templateFileLines)
    {

      my $str = $line;

      $str =~ s/TYPE1/$type1/g;
      $str =~ s/TYPE2/$type2/g;

      print $mainFileHandle $str;
    }
  }
}

print $mainFileHandle "  }";
print $mainFileHandle "}";

close($mainFileHandle) or die $!;
